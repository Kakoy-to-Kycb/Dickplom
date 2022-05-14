using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopushok
{
    public partial class Product
    {
        public string LogoProd => Image == null ? "/Resources/picture.png" : Image;

        public string MaterialsList
        {
            get
            {
                string materials = "";
                int i = 0;

                foreach (var item in ProductMaterial)
                {
                    if (i == 3)
                        materials += "\r\n";

                    i++;
                    materials += item.Material.Title;

                    if (item != ProductMaterial.Last())
                    {

                        materials += ", ";
                    }
                }
                return materials;
            }
            set { }
        }

        public decimal Price
        {
            get
            {
                decimal price = 0;

                foreach (var item in ProductMaterial)
                {
                    
                    price += item.Material.Cost;
                }
                return price;
            }
            set { }
        }
    }


}
