using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Broker.Pages;
using Broker.Class;
using System.Data.SqlClient;

namespace Broker.Class
{
    class Model
    {
       string connection = @"Data Source=DESKTOP-D72K1GC\SQLEXPRESS;Initial Catalog=Broker;Integrated Security=True";
       string part,query,id,Code,IdBr;
       double k = 1, cost=1;
        // this method chrck in database exist user or not, if exist get user's Fullname and id 
        public void CheckInvestor(string email,string psw)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "select IDInvestor, FullName from Investor where Email=@email and Password=@psw";
                SqlCommand command = new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@psw", psw);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GetName.Get((string)reader[1]);
                        GetId.Get((string)reader[0]);
                        Manager.MainFrame.Navigate(new YourAccount());
                    }
                    
                }
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        public void CheckEmp(string email,string psw)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "select FullName from [dbo].[Employee] where [IDEmployee]=@email and [Password]=@psw";
                SqlCommand command = new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@psw", psw);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GetName.Get((string)reader[0]);
                        GetId.Get(email);
                        Manager.MainFrame.Navigate(new AccountEmp());
                    }

                }
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        //this method upload datagrid  user's data from database and multiple value on k (default 1 (it is doollar per another value))
        public void BrokerageAccount(DataGrid tbc, int cmb)
        {
            List <Brokerage> list= new List<Brokerage>();
            switch (cmb)
            {
                case 0:
                    break;
                case 1:
                    k = 75;
                    break;
                case 2:
                    k = 0.96;
                    break;
            }
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "select [NameOfCompany],cast([CostSecurities] as float)*@k as [CostPurchased],[CountSecurities],cast([EPS] as int) as [EPS],cast([CurrentCost] as float)*@k as [CostCurrent],[IDBroker] from [dbo].[BrokerageAccount]  join [dbo].[Securities]  on [dbo].[BrokerageAccount].[CodeSecurities]=[dbo].[Securities].[CodeSecurities] join [dbo].[Placement]  on [dbo].[Securities].CodeSecurities=[dbo].[Placement].CodeSecurities join [dbo].[Issuer]  on [dbo].[Placement].[IDIssuer]=[dbo].[Issuer] .IDIssuer join [dbo].[Company] on [dbo].[Company].[IDCompany]=[dbo].[Issuer].[IDCompany]  where [dbo].[BrokerageAccount].[IDInvestor]=@Id";
                SqlCommand command=new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@k", k);
                command.Parameters.AddWithValue("@Id", GetId.Id);
                SqlDataReader reader=command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Brokerage((string)reader[0], (double)reader[1], (int)reader[2], (int)reader[3], (double)reader[4]));
                        GetBrokerId.GetBr((string)reader[5]);
                    }
                   tbc.ItemsSource = list;
                }
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        //this method upload datagrid market's data from database and multiple value on k(default 1(it is dollar per another value))
        public void Market(DataGrid tbc, int cmb)
        {
            List<Market> list = new List<Market>();
            switch (cmb)
            {
                case 0:
                    break;
                case 1:
                    k = 75;
                    break;
                case 2:
                    k = 0.96;
                    break;
            }
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "select [NameOfCompany],[Description],[NameSegment],[CurrentCost]*@k as [CurrentCost],[Denomination]*@k as [Denomination], cast([EPS] as int) as [EPS] from [dbo].[Company] join [dbo].[Issuer] on [dbo].[Company].[IDCompany]=[dbo].[Issuer].[IDCompany] join [dbo].[Placement] on [dbo].[Issuer].[IDIssuer]=[dbo].[Placement].[IDIssuer] join [dbo].[Securities] on [dbo].[Securities].[CodeSecurities]=[dbo].[Placement].[CodeSecurities] join [dbo].[TypeSecurities] on [dbo].[TypeSecurities].[Type]=[dbo].[Securities].[Type] join [dbo].[Segment] on [dbo].[Segment].[IDSegment]=[dbo].[Company].[IDSegment]";
                SqlCommand command = new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@k", k);
                command.Parameters.AddWithValue("@Id", GetId.Id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Market((string)reader[0], (string)reader[1], (string)reader[2], (double)reader[3], (double)reader[4], (int)reader[5]));
                    }
                    tbc.ItemsSource = list;
                }
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        public void OrderMarket(int cmb_1, int cmb_2, DataGrid dgd)
        {
            List<Market> list = new List<Market>();
            switch (cmb_1)
            {
                case 0:
                    query = "select [NameOfCompany],[Description],[NameSegment],[CurrentCost],[Denomination], cast([EPS] as int) as [EPS] from [dbo].[Company] join [dbo].[Issuer] on [dbo].[Company].[IDCompany] =[dbo].[Issuer].[IDCompany] join [dbo].[Placement] on [dbo].[Issuer].[IDIssuer] =[dbo].[Placement].[IDIssuer] join [dbo].[Securities] on [dbo].[Securities].[CodeSecurities] =[dbo].[Placement].[CodeSecurities] join [dbo].[TypeSecurities] on [dbo].[TypeSecurities].[Type] =[dbo].[Securities].[Type] join [dbo].[Segment] on [dbo].[Segment].[IDSegment] =[dbo].[Company].[IDSegment] order by [dbo].[Securities].[CurrentCost]";
                    break;
                case 1:
                    query = "select [NameOfCompany],[Description],[NameSegment],[CurrentCost],[Denomination], cast([EPS] as int) as [EPS] from [dbo].[Company] join [dbo].[Issuer] on [dbo].[Company].[IDCompany] =[dbo].[Issuer].[IDCompany] join [dbo].[Placement] on [dbo].[Issuer].[IDIssuer] =[dbo].[Placement].[IDIssuer] join [dbo].[Securities] on [dbo].[Securities].[CodeSecurities] =[dbo].[Placement].[CodeSecurities] join [dbo].[TypeSecurities] on [dbo].[TypeSecurities].[Type] =[dbo].[Securities].[Type] join [dbo].[Segment] on [dbo].[Segment].[IDSegment] =[dbo].[Company].[IDSegment] order by [dbo].[Company].[NameOfCompany]";
                    break;
                case 2:
                    query = "select [NameOfCompany],[Description],[NameSegment],[CurrentCost],[Denomination], cast([EPS] as int) as [EPS] from [dbo].[Company] join [dbo].[Issuer] on [dbo].[Company].[IDCompany] =[dbo].[Issuer].[IDCompany] join [dbo].[Placement] on [dbo].[Issuer].[IDIssuer] =[dbo].[Placement].[IDIssuer] join [dbo].[Securities] on [dbo].[Securities].[CodeSecurities] =[dbo].[Placement].[CodeSecurities] join [dbo].[TypeSecurities] on [dbo].[TypeSecurities].[Type] =[dbo].[Securities].[Type] join [dbo].[Segment] on [dbo].[Segment].[IDSegment] =[dbo].[Company].[IDSegment] order by [dbo].[Segment].[NameSegment]";
                    break;
                case 3:
                    query = "select [NameOfCompany],[Description],[NameSegment],[CurrentCost],[Denomination], cast([EPS] as int) as [EPS] from [dbo].[Company] join [dbo].[Issuer] on [dbo].[Company].[IDCompany] =[dbo].[Issuer].[IDCompany] join [dbo].[Placement] on [dbo].[Issuer].[IDIssuer] =[dbo].[Placement].[IDIssuer] join [dbo].[Securities] on [dbo].[Securities].[CodeSecurities] =[dbo].[Placement].[CodeSecurities] join [dbo].[TypeSecurities] on [dbo].[TypeSecurities].[Type] =[dbo].[Securities].[Type] join [dbo].[Segment] on [dbo].[Segment].[IDSegment] =[dbo].[Company].[IDSegment] where [dbo].[TypeSecurities].[Description]='Shares ,stonks' or [dbo].[TypeSecurities].[Description]='Shares ,dividends' order by [dbo].[Securities].[CurrentCost]";
                    break;
                case 4:
                    query = "select [NameOfCompany],[Description],[NameSegment],[CurrentCost],[Denomination], cast([EPS] as int) as [EPS] from [dbo].[Company] join [dbo].[Issuer] on [dbo].[Company].[IDCompany] =[dbo].[Issuer].[IDCompany] join [dbo].[Placement] on [dbo].[Issuer].[IDIssuer] =[dbo].[Placement].[IDIssuer] join [dbo].[Securities] on [dbo].[Securities].[CodeSecurities] =[dbo].[Placement].[CodeSecurities] join [dbo].[TypeSecurities] on [dbo].[TypeSecurities].[Type] =[dbo].[Securities].[Type] join [dbo].[Segment] on [dbo].[Segment].[IDSegment] =[dbo].[Company].[IDSegment] where [dbo].[TypeSecurities].[Description]='Federal bonds' or [dbo].[TypeSecurities].[Description]='Company bonds' order by [dbo].[Securities].[CurrentCost]";
                    break;
            }
            switch (cmb_2)
            {
                case 0:
                    part = " desc";
                    break;
                case 1:
                    part = " asc";
                    break;
            }
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                SqlCommand command = new SqlCommand(query+part, sql);
                
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Market((string)reader[0], (string)reader[1], (string)reader[2], (double)reader[3], (double)reader[4], (int)reader[5]));
                    }
                    dgd.ItemsSource = list;
                }
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        //this method sign up
        public void SignUp(string email, string psw, string Name, string country, DateTime date, string bank)
        {
            InputIdInvestor.Input(IdInvestor(Name, CodeCountry(country)));
            GetName.Get(Name);
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "insert [dbo].[Investor]([IDInvestor],[Citizenship],[FullName],[BankDetails],[Email],[Password],[DateOFBirth]) values (@id, @code, @name, @bank, @email, @psw, @date)";
                SqlCommand command = new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@id", IdInvestor(Name, country));
                command.Parameters.AddWithValue("@code", CodeCountry(country));
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@bank", bank);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@psw", psw);
                command.Parameters.AddWithValue("@date", date);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Ты успешно зарегистрирован");
                    }

                }
                sql.Close();
                Manager.MainFrame.Navigate(new AddBrokerage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        public void Update(string email, string psw, string Name, string country, DateTime date, string bank)
        {
            InputIdInvestor.Input(IdInvestor(Name, CodeCountry(country)));
            GetName.Get(Name);
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "  update [dbo].[Investor] set [Citizenship]=@code,[FullName]=@name,[BankDetails]=@bank,[Email]=@email,[Password]=@psw,[DateOFBirth]=@date where [IDInvestor]=@id";
                SqlCommand command = new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@id", GetId.Id);
                command.Parameters.AddWithValue("@code", CodeCountry(country));
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@bank", bank);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@psw", psw);
                command.Parameters.AddWithValue("@date", date);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Ты успешно обновил данные, Id осталось тем же");
                        Manager.MainFrame.Navigate(new YourAccount());
                    }

                }
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        //output IdInvestor, input FullName Investor and Country
        public string IdInvestor(string name, string code)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "select substring(@name,5,3)+substring(@code,1,1)+lower(substring(@code,2,3))";
                SqlCommand command = new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@name",name);
                command.Parameters.AddWithValue("@code", code);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = (string)reader[0];
                    }

                }
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
            return id;
        }
        //output CodeCoutry, input CountryName
        public string CodeCountry(string country)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "select CountryCode from Country where NameOfCountry=@code";
                SqlCommand command = new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@code", country);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                      Code=(string)reader[0];
                    }

                }
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
            return Code;
        }
        //input NameOfBroker, output BrokerId
        public string IdBroker(string id)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "select [IDBroker] [dbo].[Broker] from where [NameOfBorker]=@code";
                SqlCommand command = new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@code", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       IdBr = (string)reader[0];
                        GetBrokerId.GetBr(IdBr);
                    }

                }
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
            return IdBr;

        }
        public void OpenBrokerage( string desc, string br, double money  )
        {
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "insert [dbo].[BrokerageAccount]([IDName],[Description],[IDBroker],[Money]) values (@id,@desc,@br,@money)";
                SqlCommand command = new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@id", GetBrokerId.IdBr);
                command.Parameters.AddWithValue("@desc", desc);
                command.Parameters.AddWithValue("@br", br);
                command.Parameters.AddWithValue("@money", money);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Ты успешно зарегистрирован");
                    }

                }
                Manager.MainFrame.Navigate(new YourAccount());
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        public void Create( double k, int Req)
        {
            try
            {
                SqlConnection sql=new SqlConnection(connection);
                sql.Open();
                query = "insert [dbo].[Request] ([IDInvestor],[IDBroker],[CodeSecurities],[Cost],[CountPurchase],[CodeRequest]) values (@id,@BR,@code,@cost,@k,@req)";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.Parameters.AddWithValue("@id", GetId.Id);
                cmd.Parameters.AddWithValue("@BR",GetBrokerId.IdBr);
                cmd.Parameters.AddWithValue("@code", CodeSecrities(GetNameCompany.NameCompany));
                cmd.Parameters.AddWithValue("@cost", Cost(GetNameCompany.NameCompany));
                cmd.Parameters.AddWithValue("@k", k);
                cmd.Parameters.AddWithValue("@req", Req);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Заявка умпешно принята");
                        Manager.MainFrame.Navigate(new YourAccount());
                    }
                }
                sql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         public string CodeSecrities(string data)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "select  [dbo].[Securities].[CodeSecurities] from [dbo].[Securities] join [dbo].[Placement] on  [dbo].[Placement].CodeSecurities=[dbo].[Securities].CodeSecurities join [dbo].[Issuer] on  [dbo].[Issuer].IDIssuer=[dbo].[Placement].IDIssuer join [dbo].[Company] on [dbo].[Company].IDCompany=[dbo].[Issuer].IDCompany where [dbo].[Company].NameOfCompany=@name";
                SqlCommand command = new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@name", data);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data = (string)reader[0];
                    }
                }
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }
        public double Cost(string name)
        {
               try
                {
                    SqlConnection sql = new SqlConnection(connection);
                    sql.Open();
                    query = "select CurrentCost from [dbo].[Securities] join [dbo].[Placement] on  [dbo].[Placement].CodeSecurities=[dbo].[Securities].CodeSecurities join [dbo].[Issuer] on  [dbo].[Issuer].IDIssuer=[dbo].[Placement].IDIssuer join [dbo].[Company] on [dbo].[Company].IDCompany=[dbo].[Issuer].IDCompany where [dbo].[Company].NameOfCompany=@name";
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@name", name);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cost= (double)reader[0];
                        }
                    }
                    sql.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return cost;
            }
        //upload in combobox data from table country
        public void Country(ComboBox cmb)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "select NameOfCountry from Country";
                SqlCommand command = new SqlCommand(query, sql);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read()) 
                    { 
                        cmb.Items.Add((string)reader[0]); 
                    }
                   
                }
                sql.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        //upload in combobox data from table broker
        public void Broker(ComboBox cmb)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                query = "select 'Название брокера: '+[NameOfBorker]+' кол-во лет: '+cast([AgeOFBroker] as varchar(3))+' кол-во пользователей: '+cast([CountClinets] as varchar(max)) from [dbo].[Broker]";
                SqlCommand command = new SqlCommand(query, sql);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cmb.Items.Add((string)reader[0]);
                    }

                }
                sql.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        public void Puchase(ComboBox cmb)
        {
            try
            {
                SqlConnection sql=new SqlConnection(connection);
                sql.Open();
                query = "select [NameOfCompany] from [dbo].[Company]";
                SqlCommand command=new SqlCommand(query, sql);
                SqlDataReader reader=command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cmb.Items.Add((string)reader[0]);
                    }
                }
                sql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Sale(ComboBox cmb)
        {
            try
            {
                SqlConnection sql=new SqlConnection(connection);
                sql.Open();
                query = "select [NameOfCompany] from [dbo].[Company] join [dbo].[Issuer] on  [dbo].[Company].IDCompany=[dbo].[Issuer].IDCompany join [dbo].[Placement] on [dbo].[Issuer].IDIssuer=[dbo].[Placement].IDIssuer join [dbo].[Securities] on [dbo].[Placement].CodeSecurities=[dbo].[Securities].CodeSecurities join [dbo].[BrokerageAccount] on [dbo].[BrokerageAccount].CodeSecurities=[dbo].[Securities].CodeSecurities where [dbo].[BrokerageAccount].IDInvestor=@id";
                SqlCommand command = new SqlCommand(query, sql);
                command.Parameters.AddWithValue("@id",GetId.Id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cmb.Items.Add((string)reader[0]);
                    }
                }
                sql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}