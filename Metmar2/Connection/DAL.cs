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
        
        public List<Klienci> GetList()
        {
            using (EntityModel context = new EntityModel())
            {
                var model = (from klientci in context.Klienci
                             where klientci.IsActive == true
                             orderby klientci.Id
                             select klientci).ToList();

                return model;
            }
        }

        internal void DodajKlienta(KlientModel model)
        {

            using (EntityModel context = new EntityModel())
            {
                var klient = new Klienci();
                klient.Imie = model.Imie;
                klient.Nazwisko = model.Nazwisko;
                klient.Pesel = model.Pesel;
                klient.Telefon = model.Telefon;
                klient.IsActive = model.IsActive;
                klient.Adres = model.Adres;

                context.Klienci.Add(klient);
                context.SaveChanges();
            }
        }

        internal void KlientUpdate(Klienci model)
        {
            using (EntityModel context = new EntityModel())
            {
                var klient = context.Klienci.Where(oKlient => oKlient.Pesel == model.Pesel).FirstOrDefault();
                klient.Imie = model.Imie;
                klient.Nazwisko = model.Nazwisko;
                klient.Pesel = model.Pesel;
                klient.Telefon = model.Telefon;
                klient.Adres = model.Adres;
                klient.IsActive = model.IsActive;

                context.SaveChanges();
            }
        }

        public List<Kategorie> FillComboKat()
        {
            using (EntityModel context = new EntityModel())
            {
                var kategorie = (from okategorie in context.Kategorie
                                 orderby okategorie.Nazwa
                                 select okategorie).ToList();
                return kategorie;
            }
        }

        public List<ItemModel> FillComboNazw(int idKat)
        {
            List<ItemModel> list = new List<ItemModel>();
            string query = $"SELECT p.Id as Id,p.Nazwa as NazwaPrzedmiotu, k.Nazwa as NazwaKat ,IdKategorii,Kaucja,StawkaDzien,StawkaGodzinowa,Cena,IsPrice,Wartosc,IsSki FROM Przedmioty p" +
                $" join Kategorie k on p.IdKategorii = k.Id" +
                $" where IdKategorii = {idKat} ORDER BY p.Nazwa";
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                        {
                            var ItemModel = new ItemModel();
                            ItemModel.NazwaPrzedmiotu = Convert.ToString(dr["NazwaPrzedmiotu"]);
                            ItemModel.Id = Convert.ToInt32(dr["Id"]);
                            ItemModel.Kaucja = Convert.ToDecimal(dr["Kaucja"]);
                            ItemModel.Cena = Convert.ToDecimal(dr["Cena"]);
                            ItemModel.StawkaDzien = Convert.ToDecimal(dr["StawkaDzien"]);
                            ItemModel.StawkaGodzina = Convert.ToDecimal(dr["StawkaGodzinowa"]);
                            ItemModel.IsPrice = Convert.ToBoolean(dr["IsPrice"]);
                            ItemModel.Wartosc = Convert.ToInt32(dr["Wartosc"]);
                            ItemModel.IsSki = Convert.ToInt32(dr["IsSki"]);
                            list.Add(ItemModel);
                        }
                }
            }
            return list;
        }

        public Klienci FillKlientByPesel(string pesel)
        {
            using (EntityModel context = new EntityModel())
            {
                var klient = context.Klienci.FirstOrDefault(oklient => oklient.Pesel == pesel);
                return klient;
            }
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
    }

}
