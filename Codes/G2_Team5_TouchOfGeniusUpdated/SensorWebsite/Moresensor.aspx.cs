using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Using DB
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.DataVisualization.Charting;
using System.Text.RegularExpressions;
using System.Web.Script.Services;
using System.Web.Services;
using System.Net;
using System.Web.Script.Serialization;
using System.Globalization;


public partial class Moresensor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            UpdatePanel1.Visible = true;
            UpdatePanel2.Visible = false;
            lblusername.Text = Session["Username"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SensorDB"].ConnectionString);
            con.Open();
            string getuserid = "SELECT *FROM Users WHERE Username='" + lblusername.Text + "'";
            SqlCommand cmd1 = new SqlCommand(getuserid, con);
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                lblUserID.Text = reader["UserID"].ToString();
                lbllastlogin.Text = reader["LastLogin"].ToString();
            }
            con.Close();
        }
        else
        {
            Response.Redirect("Homeguest.aspx");
        }
        ChartTemperature.Series["Temperature"].ToolTip = " #VALX | #VALY";
        ChartUltrasonic.Series["Distance"].ToolTip = " #VALX | #VALY";
        ChartUltrasonic.Series[0].Color = System.Drawing.Color.Green;
        ChartTemperature.Series[0].Color = System.Drawing.Color.Red;
    }
    public static List<string> CountryList()
    {
        List<string> CultureList = new List<string>();
        CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

        foreach (CultureInfo getCulture in getCultureInfo)
        {
            RegionInfo GetRegionInfo = new RegionInfo(getCulture.LCID);

            if (!(CultureList.Contains(GetRegionInfo.EnglishName)))
            {
                CultureList.Add(GetRegionInfo.EnglishName);
            }
        }
        CultureList.Sort();
        return CultureList;
    }

    protected void ddlChart_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChartMode();

    }
    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView5.PageIndex = e.NewPageIndex;
        GridView5.DataSource = Motion;
        GridView5.DataBind();
        ChartMode();
        UpdatePanel5.Update();
    }
    protected void GridView6_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView6.PageIndex = e.NewPageIndex;
        GridView6.DataSource = RFID;
        GridView6.DataBind();
        ChartMode();
        UpdatePanel6.Update();

    }
    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView4.PageIndex = e.NewPageIndex;
        GridView4.DataSource = Ultrasonic;
        GridView4.DataBind();
        ChartMode();
        UpdatePanel3.Update();

    }
    protected void GridView3_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        GridView3.DataSource = Temperature;
        GridView3.DataBind();
        ChartMode();
        UpdatePanel2.Update();

    }
    protected void TemperatureRefresh()
    {
        ChartTemperature.DataSourceID = null;
        String conn = ConfigurationManager.ConnectionStrings["SensorDatabaseConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        DataSet ds = new DataSet();
        con.Open();
        SqlDataAdapter adapter = new SqlDataAdapter("Select Temperature, Timestamp from Temperature", con);
        adapter.Fill(ds);
        ChartTemperature.DataSource = ds;
        ChartTemperature.Series["Temperature"].XValueMember = "Timestamp";
        ChartTemperature.Series["Temperature"].YValueMembers = "Temperature";
        con.Close();
        ChartMode();
    }
    protected void UltrasonicRefresh()
    {
        ChartUltrasonic.DataSourceID = null;
        String conn = ConfigurationManager.ConnectionStrings["SensorDatabaseConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        DataSet ds = new DataSet();
        con.Open();
        SqlDataAdapter adapter = new SqlDataAdapter("Select Distance, Timestamp from Ultrasonic", con);
        adapter.Fill(ds);
        ChartUltrasonic.DataSource = ds;
        ChartUltrasonic.Series["Distance"].XValueMember = "Timestamp";
        ChartUltrasonic.Series["Distance"].YValueMembers = "Distance";
        con.Close();
        ChartMode();
    }

    private void ChartMode()
    {
        string selected = this.ddlChart.SelectedItem.Text;
        switch (selected)
        {
            case "StackedArea":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedArea;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedArea;
                break;
            case "StackedBar":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedBar;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedBar;
                break;
            case "StackedColumn":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn;
                break;
            case "Area":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Area;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Area;
                break;
            case "Bar":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
                break;
            case "Bubble":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bubble;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bubble;
                break;
            case "Column":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                break;
            case "Funnel":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Funnel;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Funnel;
                break;
            case "Kagi":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Kagi;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Kagi;
                break;
            case "FastPoint":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.FastPoint;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.FastPoint;
                break;
            case "FastLine":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.FastLine;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.FastLine;
                break;
            case "Line":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                break;
            case "Spline":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
                break;
            case "SplineArea":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.SplineArea;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.SplineArea;
                break;
            case "SplineRange":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.SplineRange;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.SplineRange;
                break;
            case "Renko":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Renko;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Renko;
                break;
            case "Stock":
                ChartTemperature.Series["Temperature"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Stock;
                ChartUltrasonic.Series["Distance"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Stock;
                break;
        }
    }
    protected void btnRefreshTemperature_Click(object sender, EventArgs e)
    {
        TemperatureRefresh();
    }
    protected void btnRefreshUltrasonic_Click(object sender, EventArgs e)
    {
        UltrasonicRefresh();
    }
    protected void btnExecute_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;

        Response.AddHeader("content-disposition",
         "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        PrepareForExport(GridView3);
        PrepareForExport(GridView4);
        PrepareForExport(GridView5);
        PrepareForExport(GridView6);

        Table tb = new Table();
        TableRow tr1 = new TableRow();
        TableCell cell1 = new TableCell();
        cell1.Controls.Add(GridView3);
        tr1.Cells.Add(cell1);
        TableCell cell3 = new TableCell();
        cell3.Controls.Add(GridView4);
        TableCell cell2 = new TableCell();
        TableCell cell4 = new TableCell();
        cell4.Controls.Add(GridView5);
        TableCell cell5 = new TableCell();
        cell5.Controls.Add(GridView6);
        {
            TableRow tr2 = new TableRow();
            tr2.Cells.Add(cell2);
            TableRow tr3 = new TableRow();
            tr3.Cells.Add(cell3);
            TableRow tr4 = new TableRow();
            tr4.Cells.Add(cell4);
            TableRow tr5 = new TableRow();
            tr5.Cells.Add(cell5);
            tb.Rows.Add(tr1);
            tb.Rows.Add(tr2);
            tb.Rows.Add(tr3);
            tb.Rows.Add(tr4);
            tb.Rows.Add(tr5);
        }
        tb.RenderControl(hw);

        //style to format numbers to string
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void PrepareForExport(GridView Gridview)
    {
        Gridview.DataBind();

        //Change the Header Row back to white color
        Gridview.HeaderRow.Style.Add("background-color", "#FFFFFF");

        //Apply style to Individual Cells
        for (int k = 0; k < Gridview.HeaderRow.Cells.Count; k++)
        {
            Gridview.HeaderRow.Cells[k].Style.Add("background-color", "green");
        }

        for (int i = 0; i < Gridview.Rows.Count; i++)
        {
            GridViewRow row = Gridview.Rows[i];

            //Change Color back to white
            row.BackColor = System.Drawing.Color.White;

            //Apply text style to each Row
            row.Attributes.Add("class", "textmode");

            //Apply style to Individual Cells of Alternating Row
            if (i % 2 != 0)
            {
                for (int j = 0; j < Gridview.Rows[i].Cells.Count; j++)
                {
                    row.Cells[j].Style.Add("background-color", "#C2D69B");
                }
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void btnExecuteChart_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=TempChartExport.xls");
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        ChartTemperature.RenderControl(hw);
        string src = Regex.Match(sw.ToString(), "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1].Value;
        string img = string.Format("<img src = '{0}{1}' />", Request.Url.GetLeftPart(UriPartial.Authority), src);

        Table table = new Table();
        TableRow row = new TableRow();
        row.Cells.Add(new TableCell());
        row.Cells[0].Width = 200;
        row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        row.Cells[0].Controls.Add(new Label { Text = "Temperature Chart", ForeColor = System.Drawing.Color.Red });
        table.Rows.Add(row);
        row = new TableRow();
        row.Cells.Add(new TableCell());
        row.Cells[0].Controls.Add(new Literal { Text = img });
        table.Rows.Add(row);

        sw = new StringWriter();
        hw = new HtmlTextWriter(sw);
        table.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    protected void btnExecuteChartUltra_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=UltrasonicChartExport.xls");
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        ChartUltrasonic.RenderControl(hw);
        string src = Regex.Match(sw.ToString(), "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1].Value;
        string img = string.Format("<img src = '{0}{1}' />", Request.Url.GetLeftPart(UriPartial.Authority), src);

        Table table = new Table();
        TableRow row = new TableRow();
        row.Cells.Add(new TableCell());
        row.Cells[0].Width = 200;
        row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        row.Cells[0].Controls.Add(new Label { Text = "Ultrasonic Chart", ForeColor = System.Drawing.Color.Red });
        table.Rows.Add(row);
        row = new TableRow();
        row.Cells.Add(new TableCell());
        row.Cells[0].Controls.Add(new Literal { Text = img });
        table.Rows.Add(row);

        sw = new StringWriter();
        hw = new HtmlTextWriter(sw);
        table.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    protected void GetWeatherInfo(object sender, EventArgs e)
    {
        string appId = "159d0d438da2af04cfa485a55f79319b";
        string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt=1&APPID={1}", txtCity.Text.Trim(), appId);
        using (WebClient client = new WebClient())
            try
            {
                string json = client.DownloadString(url);

                WeatherInfo weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(json);
                lblCity_Country.Text = weatherInfo.city.name + ", " + weatherInfo.city.country;
                imgCountryFlag.ImageUrl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherInfo.city.country.ToLower());
                lblDescription.Text = weatherInfo.list[0].weather[0].description;
                imgWeatherIcon.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfo.list[0].weather[0].icon);
                lblTempMin.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.min, 1));
                lblTempMax.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.max, 1));
                lblTempDay.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.day, 1));
                lblTempNight.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.night, 1));
                lblHumidity.Text = weatherInfo.list[0].humidity.ToString();
                tblWeather.Visible = true;

            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
    }

    public class WeatherInfo
    {
        public City city { get; set; }
        public List<List> list { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string country { get; set; }
    }

    public class Temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
    }

    public class Weather
    {
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class List
    {
        public Temp temp { get; set; }
        public int humidity { get; set; }
        public List<Weather> weather { get; set; }
    }
    protected void GridView6_DataBound(object sender, EventArgs e)
    {
    }
    protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell cell = e.Row.Cells[0];
            cell.ForeColor = System.Drawing.Color.Red;
            cell.Font.Bold = true;
        }
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell cell = e.Row.Cells[1];
            cell.ForeColor = System.Drawing.Color.Red;
            cell.Font.Bold = true;
        }
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell cell = e.Row.Cells[2];
            cell.ForeColor = System.Drawing.Color.Red;
            cell.Font.Bold = true;
        }
    }
    protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell cell = e.Row.Cells[1];
            cell.ForeColor = System.Drawing.Color.Red;
            cell.Font.Bold = true;
        }
    }
    protected void GridView7_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TimerTime_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
    }
}