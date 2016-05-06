using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ImageProcess.filters
{
    class count
    {
        Bitmap imagem;
        public count(Bitmap bmp)
        {
            imagem = bmp;
        }

        public Bitmap contar() 
        {
            int contador = 0;
            //Bitmap newImage = (Bitmap)bmp.Clone();
            Color novaCor = Color.FromArgb(255, 0, 0, 0);
            
            for (int i = 1; i < imagem.Width-1; i++)
            {
                for(int j = 1; j < imagem.Height-1; j++)
                {
                    var px = imagem.GetPixel(i, j).R;
                    if (px == 0)
                    {
                        
                        //System.Console.WriteLine("Entrouuuu");
                        contador++;
                        apagarVizinhos(i, j);
                    }
                }
            }
            System.Console.WriteLine("Objetos: " + contador);
            return imagem;
        }

        public void apagarVizinhos(int i, int j)
        {
            Color novaOutraCor = Color.FromArgb(255, 255, 255, 255);
            var px = imagem.GetPixel(i, j).R;
            if (px == 0)
            {
               // System.Console.WriteLine("OIIIIIIIIIIIIIIIIIII");
                imagem.SetPixel(i, j, novaOutraCor);
                apagarVizinhos(i, j - 1);
                apagarVizinhos(i-1, j);
                apagarVizinhos(i, j + 1);
                apagarVizinhos(i+1, j);
              
         //       newImage.SetPixel(i, j - 1, novaOutraCor);
         //       newImage.SetPixel(i - 1, j, novaOutraCor);
         //      newImage.SetPixel(i, j + 1, novaOutraCor);
         //      newImage.SetPixel(i + 1, j, novaOutraCor);
            }
           
        }
    }
}
