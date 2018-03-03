using Metmar2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;

namespace Metmar2.Connection
{
    public class DAL
    {
        private static string _connString = "Data Source=Lenovo-PC\\SQLExpress;Initial Catalog=Cennik;Integrated Security=True";
        
        public List<KlientModel> GetList()
        {
            string query = "Select Id, Imie, Nazwisko, Pesel, Telefon from Klienci";
            List<KlientModel> list = new List<KlientModel>();
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(query,connection))
                {
                    cmd.Connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var klientModel = new KlientModel();
                            klientModel.Id = Convert.ToInt32(dr["Id"]);
                            klientModel.Nazwisko = Convert.ToString(dr["Nazwisko"]);
                            klientModel.Imie = Convert.ToString(dr["Imie"]);
                            klientModel.Pesel = Convert.ToString(dr["Pesel"]);
                            klientModel.Telefon = Convert.ToString(dr["Telefon"]);
                            list.Add(klientModel);
                        }
                    }
                }
            }
            return list;
        }

        internal void DaneKlientaDodaj(KlientModel klient)
        {
            throw new NotImplementedException();
        }

        internal void DaneKlientaUpdate(KlientModel klient)
        {
            throw new NotImplementedException();
        }

        public List<ItemModel> FillComboKat()
        {
            List<ItemModel> list = new List<ItemModel>();
            string query = "SELECT Id,Nazwa FROM Kategorie ";
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                        {
                            var ItemModel = new ItemModel();
                            ItemModel.NazwaKategori = Convert.ToString(dr["Nazwa"]);
                            ItemModel.Id = Convert.ToInt32(dr["Id"]);
                            list.Add(ItemModel);
                        }
                }
            }
            return list;
        }

        public List<ItemModel> FillComboNazw(int idKat)
        {
            List<ItemModel> list = new List<ItemModel>();
            string query = $"SELECT p.Id as Id,p.Nazwa as NazwaPrzedmiotu, k.Nazwa as NazwaKat ,IdKategorii,Kaucja,StawkaDzien,StawkaGodzinowa,Cena,IsPrice FROM Przedmioty p" +
                $" join Kategorie k on p.IdKategorii = k.Id" +
                $" where IdKategorii = {idKat}";
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                        {
                            var ItemModel = new ItemModel();
                            ItemModel.NazwaKategori = Convert.ToString(dr["NazwaKat"]);
                            ItemModel.NazwaPrzedmiotu = Convert.ToString(dr["NazwaPrzedmiotu"]);
                            ItemModel.Id = Convert.ToInt32(dr["Id"]);
                            ItemModel.Kaucja = Convert.ToDecimal(dr["Kaucja"]);
                            ItemModel.Cena = Convert.ToDecimal(dr["Cena"]);
                            ItemModel.StawkaDzien = Convert.ToDecimal(dr["StawkaDzien"]);
                            ItemModel.StawkaGodzina = Convert.ToDecimal(dr["StawkaGodzinowa"]);
                            ItemModel.IsPrice = Convert.ToBoolean(dr["IsPrice"]);
                            list.Add(ItemModel);
                        }
                }
            }
            return list;
        }

        public KlientModel FillKlientByPesel(string pesel)
        {
            KlientModel klient = null;
            string query = $"select Id, Imie, Nazwisko,Pesel, Telefon from Klienci where Pesel = '{pesel}';";
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            klient = new KlientModel();
                            klient.Id = Convert.ToInt32(dr["Id"]);
                            klient.Imie = Convert.ToString(dr["Imie"]);
                            klient.Nazwisko = Convert.ToString(dr["Nazwisko"]);
                            klient.Pesel = Convert.ToString(dr["Pesel"]);
                            klient.Telefon = Convert.ToString(dr["Telefon"]);

                        }
                    }
                }
            }
            return klient;
        }

        public int FakturaDodaj(BindingList<ItemModel> list, int idKlient)
        {

            int NewIdFaktura = 0;
            var suma = list.Sum(x => x.SumaZaPrzedmiot);
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Faktura(IdKlienta ,Data, Suma) VALUES (@IdKlienta ,@Data, @Suma);SELECT scope_identity();", connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdKlienta", idKlient);
                    cmd.Parameters.AddWithValue("@Data", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@Suma", suma);

                    NewIdFaktura = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (ItemModel item in list)
                    {
                        using (SqlCommand cmd2 = new SqlCommand("INSERT INTO FakturaPrzedmiot (IdFaktura, IdPrzedmiot, Ilosc, IloscCzas) VALUES (@IdFaktura, @IdPrzedmiot,@Ilosc,@IloscCzas)", connection))
                        {

                            cmd2.Parameters.AddWithValue("IdFaktura", NewIdFaktura);
                            cmd2.Parameters.AddWithValue("IdPrzedmiot", item.Id);
                            cmd2.Parameters.AddWithValue("Ilosc", Convert.ToInt32(item.Ilosc));
                            cmd2.Parameters.AddWithValue("IloscCzas", Convert.ToInt32(item.IloscCzas));
                            cmd2.ExecuteNonQuery();
                        }
                    }
                }
            }
            return NewIdFaktura;
        }

        public void DaneKlientaDodaj(string imie, string nazwisko, string pesel, int telefon)
        {
            ItemModel model = new ItemModel();
            string query = $"INSERT INTO Klienci(Imie,Nazwisko,Pesel,Telefon) VALUES ('{imie}','{nazwisko}','{pesel}',{telefon});";
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DaneKlientaUsun(string pesel)
        {
            string query = $"delete from Cennik.dbo.Klienci where Pesel = '{pesel}'";
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DaneKlientaUpdate(string imie, string nazwisko, string pesel, int telefon)
        {
            string query = $"update Klienci set Imie = '{imie}', Nazwisko = '{nazwisko}', Telefon = {telefon} where Pesel = '{pesel}'";
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }

}
