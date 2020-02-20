using System;
using System.Collections.Generic;
using System.IO;

namespace CreaBloc2
{
    //classe des composants du bloc
    class ElemBlocs
    {
        private string pathTemp = @"C:\Users\beaudonnelk\Documents\TempBloc\newBloc.xrb";

        public static int largeurBloc(String chemin)
        {
            int largeur = 0;

            FileStream fs = File.OpenRead(chemin);
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(fs, System.Text.Encoding.Default);
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            
            }


            string ligne;

            int i = 0;

            try
            {

                while ((ligne = sr.ReadLine()) != null)
                {
                    if (ligne.StartsWith(@"¤#Contour¤"))
                    {
                        i = 1;
                    }
                    else if (i == 1)
                    {

                        if (!ligne.StartsWith(@"¤#"))
                        {
                            string[] split = ligne.Split('·');
                            int coordX1 = int.Parse(split[0]);
                            int coordX2 = int.Parse(split[2]);

                            int j = 0;
                            if (coordX1 > coordX2)
                            {
                                j = coordX1;
                            }
                            else
                            {
                                j = coordX2;
                            }
                            if (j > largeur)
                            {
                                largeur = j;
                            }
                            


                        }
                        else { i = 0; }
                    }

                    else { }
                }
            }
            catch (IOException e1)
            {
                Console.WriteLine(e1);
            }
            try
            {
                sr.Close();
            }
            catch (IOException e2)
            {
                Console.WriteLine(e2);
            }
            largeur -= 3200;
            return largeur;
        }

        



        
       /* 
        public void addBlock(string pathBloc)
        {
            
            FileStream fs = File.OpenRead(pathTemp);
            StreamReader sr = null;
            {
                sr = new StreamReader(fs, System.Text.Encoding.Default);
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);

            }

            string ligne;

            int largeur = largeurBloc(pathTemp);

            if (largeur == 0)
            {

            }

            try
            {
                while ((ligne = sr.ReadLine()) != null)
                {



                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erreur lecture");
            }


        }
        */

       /* public void addFirstBloc()
        {
            int compteur = 0;
            string line;
            using (System.IO.StreamReader file = new System.IO.StreamReader(seletedBloc))
            {
                using (System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(pathTemp))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if(line.StartsWith(""))
                        System.Console.WriteLine(line);
                        fileWriter.WriteLine(line);
                        compteur++;
                    }
                }
            }

        }
        */

    }
}
