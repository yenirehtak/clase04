using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace archivos
{
        public class Archivos
        {
            private string ruta= @"C:\Users\PC\source\repos\clase04\mitexto.txt";
            public string Ruta {
            get {
                return ruta;
                }
            set
            {
                ruta = value;
            }
            }

            public void LeePorLotes()
            {
                int vCapacidadDelStream = 0;
                string vLinea = null;
                int vIndice;
                try
                {
                    string[] vDesglosado = null;
                    StreamReader vLeeStreams = new StreamReader(Ruta);
                    vLinea = vLeeStreams.ReadLine(); //lectura de la linea
                    while (vLinea != null)
                    {
                        vDesglosado = this.ArregloDesglosado(vLinea); 
                        vIndice = 1; // indice para iteracion
                        foreach (string vToPrint in vDesglosado)
                        {
                            switch (vIndice)
                            {
                                case 1:
                                    Console.WriteLine("El nombre es:{0}", vToPrint); //posicion 1 del arreglo: nombre
                                    break;
                                case 2:
                                    Console.WriteLine("La cédula es:{0}", vToPrint); //posicion 2 del arreglo: cedula
                                break;
                                case 3:
                                    Console.WriteLine("El correo es:{0}", vToPrint); //posicion 3 del arreglo: correo
                                    break;
                            }
                            vIndice += 1; //iteracion
                        }
                        vLinea = vLeeStreams.ReadLine(); //repeticion de la lectura de linea
                    }
                    vLeeStreams.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Excepcion:" + e.Message);
                }
                finally
                {
                    Console.WriteLine("Ejecución del método finalizada.");
                }
            }

            public void CreaSalida() 
            {
                try        //tarea 2
                   {
                FileStream vFs = new FileStream(Ruta, FileMode.Create); //escribe en el archivo o lo crea si no existe
                string vCadena = "Carlos Franz"; 
                byte[] writeArr = Encoding.ASCII.GetBytes(vCadena);
                vFs.Write(writeArr, 0, vCadena.Length); //pasa la informacion de cadena al archivo
                vFs.Close();
                    }
                catch (Exception e)
                {
                Console.WriteLine("Excepción: ", e.Message);
                }
                finally
                {
                    Console.WriteLine("Ejecución del método finalizada.");
                }
            }

            public void LeePorLotes2()
            {
                string vAux = null;      //carga nueva informacion
                byte[] infoArchivo = new byte[1000];
                FileStream fs = new FileStream(Ruta, FileMode.Open, FileAccess.Read);
                fs.Read(infoArchivo, 0, (int)fs.Length);
                vAux = Encoding.ASCII.GetString(infoArchivo); ///tarea 3
                Console.WriteLine(vAux);
            }
            public void BorrarArchivo ()       //borra el archivo
        {
            if (!File.Exists(Ruta)) {
                throw new FileNotFoundException();
            } else
            {
                File.Delete(Ruta);
                Console.WriteLine("Se ha borrado el archivo");
            }
            
        }

            private string[] ArregloDesglosado(string vEntrada)
            {
                string[] vResult = vEntrada.Split(','); //metodo que separa los caracteres entre comas
                return vResult;
            }
        }
    }
