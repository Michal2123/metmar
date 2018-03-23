using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metmar2.Promocje
{
    public class Promocje
    {
        public string promNamioty(Label labelCena, TextBox tbCzas, ItemModel model)
        {
            var zmieniona = Convert.ToDecimal(labelCena.Text);
            if (model.Cena < 200)
            {
                if (Convert.ToInt32(tbCzas.Text) > 2 && Convert.ToInt32(tbCzas.Text) <= 7)
                {
                    zmieniona -= 5;
                }
                else if (Convert.ToInt32(tbCzas.Text) > 7)
                {
                    zmieniona -= 10;
                }

            }
            else
            {
                if (Convert.ToInt32(tbCzas.Text) > 2 && Convert.ToInt32(tbCzas.Text) <= 7)
                {
                    zmieniona -= 50;
                }
                else if (Convert.ToInt32(tbCzas.Text) > 7)
                {
                    zmieniona -= 100;
                }
            }
            return zmieniona.ToString();
        }

        public string promNarty(Label labelCena, TextBox tbCzas, ItemModel model)
        {
            var zmieniona = Convert.ToDecimal(labelCena.Text);
            if (model.IsSki == 1 && Convert.ToInt32(tbCzas.Text) <= 3)
            {
                zmieniona = 40;
            }
            else if (model.IsSki == 2 && Convert.ToInt32(tbCzas.Text) <= 3)
            {
                zmieniona = 50;
            }
            return zmieniona.ToString();
        }

        public decimal promWeekend(Label labelCena, decimal sumaPrzedmiotu, TextBox liczbaDni)
        {
            DialogResult dialogResult = MessageBox.Show("Czy chcesz dodać promocje weekendową ?", "Informacja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var liczba = Convert.ToInt32(liczbaDni.Text) / 7;
                if (liczba > 1)
                {
                    return sumaPrzedmiotu - ((Convert.ToDecimal(labelCena.Text) / 2) * liczba);
                }
                else
                {
                    return sumaPrzedmiotu - (Convert.ToDecimal(labelCena.Text) / 2);
                }
            }
            return sumaPrzedmiotu;
        }

        public decimal promWyjPrzyj(TextBox liczbaDni, decimal sumaPrzedmiotu, Label labelCena)
        {
            if (Convert.ToInt32(liczbaDni.Text) > 3)
            {
                var nowaCena = Convert.ToDecimal(labelCena.Text) * 2;
                sumaPrzedmiotu -= nowaCena;
                return sumaPrzedmiotu;
            }
            return sumaPrzedmiotu;
        }
    }
}
