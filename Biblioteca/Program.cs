using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            byte opcion = 0;
            byte control = 0;
            String ruta = @"C:\Users\Carlo\OneDrive\Escritorio\usuario.txt";
            String ruta2 = @"C:\Users\Carlo\OneDrive\Escritorio\administrador.txt";
            String ruta3 = @"C:\Users\Carlo\OneDrive\Escritorio\libros.txt";
            String ruta4 = @"C:\Users\Carlo\OneDrive\Escritorio\Usuarios libros en prestamo.txt";


            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al programa");
                Console.WriteLine("¿Quien desea ingresar?\n1.-Usuario\n2.-Administrador");
                byte menu = byte.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1://Usuario
                        {
                            Console.Clear();
                            StreamReader lectura4 = File.OpenText(ruta4);
                            string contenido4 = lectura4.ReadToEnd();
                            lectura4.Close();
                            string[] elementos4 = contenido4.Split('\n');
                            Console.WriteLine("Bienvenido a la seccion de usuarios");
                            Console.WriteLine("1.-Loggin\n2.-Registro de nuevo usuario");
                            byte menu2 = byte.Parse(Console.ReadLine());
                            switch (menu2)
                            {
                                case 1://Loggin 
                                    {
                                        Console.Clear();
                                        StreamReader lectura = File.OpenText(ruta);
                                        string contenido = lectura.ReadToEnd();
                                        lectura.Close();
                                        string[] elementos = contenido.Split('\n');
                                        Console.WriteLine("Ingresa tu usuaio");
                                        string usuario = Console.ReadLine().ToLower().Trim();
                                        for (int x = 0; x < elementos.Length; x = x + 4) //Buscamos el usuario
                                        {
                                            if (usuario.Equals(elementos[x].Trim().ToLower()))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ingresa la contraseña");
                                                string password = Console.ReadLine();
                                                if (password.Equals(elementos[x + 1].Trim()))
                                                {
                                                    StreamReader lectura3 = File.OpenText(ruta3);
                                                    String contenido3 = lectura3.ReadToEnd();
                                                    lectura3.Close();
                                                    string[] elementos3 = contenido3.Split('\n');
                                                    Console.WriteLine("Bienvenido has iniciado sesion ");
                                                    Console.WriteLine("Que deseas hacer?\n1.-Ver los libros\n2.-Solicitar un prestamo de libro\n3.-Devolucion de un libro");
                                                    byte menusuario = byte.Parse(Console.ReadLine());
                                                    switch (menusuario)
                                                    {
                                                        case 1: //Ver informacion de los libros 
                                                            {
                                                                Console.WriteLine("Ver informacion");
                                                                Console.WriteLine(contenido3);
                                                                Console.ReadKey();
                                                                break;
                                                            }
                                                        case 2: // Solicitar un prestamo 
                                                            {
                                                                if (elementos[x + 3].Trim().Equals("1") || elementos[x + 3].Trim().Equals("0") || elementos[x + 3].Trim().Equals("2"))
                                                                {

                                                                    for (int a = 0; a < elementos4.Length; a = a + 4)
                                                                    {

                                                                        if (elementos4[a + 1].Trim().Equals("disponible"))
                                                                        {
                                                                            Console.WriteLine("Que libro quieres pedir prestado ( Escribe el ISBN del libro )");
                                                                            string isbn = Console.ReadLine();
                                                                            for (int b = 0; b < elementos3.Length; b = b + 6)
                                                                            {
                                                                                if (isbn.Equals(elementos3[b].Trim()))
                                                                                {
                                                                                    int libros = Int32.Parse(elementos3[x + 4]);
                                                                                    if (libros == 0)
                                                                                    {
                                                                                        Console.WriteLine("No hay libros en existencia");
                                                                                        break;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        int prestamos = Int32.Parse(elementos[x + 3]);
                                                                                        prestamos = prestamos + 1;
                                                                                        elementos[x + 3] = Convert.ToString(prestamos);
                                                                                        StreamWriter escritura = File.CreateText(ruta);
                                                                                        for (int t = 0; t < elementos.Length; t++)
                                                                                        {
                                                                                            escritura.WriteLine(elementos[t].Trim());
                                                                                        }
                                                                                        escritura.Close();
                                                                                        int cantidad = Int32.Parse(elementos3[b + 4]);
                                                                                        cantidad = cantidad - 1;
                                                                                        elementos3[b + 4] = Convert.ToString(cantidad);
                                                                                        StreamWriter escritura3 = File.CreateText(ruta3);
                                                                                        for (int r = 0; r < elementos3.Length; r++)
                                                                                        {
                                                                                            escritura3.WriteLine(elementos3[r].Trim());
                                                                                        }
                                                                                        escritura3.Close();
                                                                                        elementos4[a+1] = isbn;
                                                                                        StreamWriter escritura4 = File.CreateText(ruta4);
                                                                                        for (int y = 0; y < elementos4.Length; y++)
                                                                                        {
                                                                                            escritura4.WriteLine(elementos4[y].Trim());
                                                                                        }
                                                                                        escritura4.Close();
                                                                                        Console.WriteLine("Se ha modificado el ISBN del libro");
                                                                                        break;
                                                                                                                                                                                           
                                                                                       
                                                                                    }
                                                                                }
                                                                            }

                                                                        }
                                                                        if (elementos4[a + 2].Trim().Equals("disponible"))
                                                                        {
                                                                            Console.WriteLine("Que libro quieres pedir prestado ( Escribe el ISBN del libro )");
                                                                            string isbn = Console.ReadLine();
                                                                            for (int b = 0; b < elementos3.Length; b = b + 6)
                                                                            {
                                                                                if (isbn.Equals(elementos3[b].Trim()))
                                                                                {
                                                                                    int libros = Int32.Parse(elementos3[x + 4]);
                                                                                    if (libros == 0)
                                                                                    {
                                                                                        Console.WriteLine("No hay libros en existencia");
                                                                                        break;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        int prestamos = Int32.Parse(elementos[x + 3]);
                                                                                        prestamos = prestamos + 1;
                                                                                        elementos[x + 3] = Convert.ToString(prestamos);
                                                                                        StreamWriter escritura = File.CreateText(ruta);
                                                                                        for (int t = 0; t < elementos.Length; t++)
                                                                                        {
                                                                                            escritura.WriteLine(elementos[t].Trim());
                                                                                        }
                                                                                        escritura.Close();
                                                                                        int cantidad = Int32.Parse(elementos3[b + 4]);
                                                                                        cantidad = cantidad - 1;
                                                                                        elementos3[b + 4] = Convert.ToString(cantidad);
                                                                                        StreamWriter escritura3 = File.CreateText(ruta3);
                                                                                        for (int r = 0; r < elementos3.Length; r++)
                                                                                        {
                                                                                            escritura3.WriteLine(elementos3[r].Trim());
                                                                                        }
                                                                                        escritura3.Close();
                                                                                        elementos4[a + 1] = isbn;
                                                                                        StreamWriter escritura4 = File.CreateText(ruta4);
                                                                                        for (int y = 0; y < elementos4.Length; y++)
                                                                                        {
                                                                                            escritura4.WriteLine(elementos4[y].Trim());
                                                                                        }
                                                                                        escritura4.Close();
                                                                                        Console.WriteLine("Se ha modificado el ISBN del libro");
                                                                                        break;


                                                                                    }
                                                                                }
                                                                            }

                                                                        }
                                                                        if (elementos4[a + 3 ].Trim().Equals("disponible"))
                                                                        {
                                                                            Console.WriteLine("Que libro quieres pedir prestado ( Escribe el ISBN del libro )");
                                                                            string isbn = Console.ReadLine();
                                                                            for (int b = 0; b < elementos3.Length; b = b + 6)
                                                                            {
                                                                                if (isbn.Equals(elementos3[b].Trim()))
                                                                                {
                                                                                    int libros = Int32.Parse(elementos3[x + 4]);
                                                                                    if (libros == 0)
                                                                                    {
                                                                                        Console.WriteLine("No hay libros en existencia");
                                                                                        break;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        int prestamos = Int32.Parse(elementos[x + 3]);
                                                                                        prestamos = prestamos + 1;
                                                                                        elementos[x + 3] = Convert.ToString(prestamos);
                                                                                        StreamWriter escritura = File.CreateText(ruta);
                                                                                        for (int t = 0; t < elementos.Length; t++)
                                                                                        {
                                                                                            escritura.WriteLine(elementos[t].Trim());
                                                                                        }
                                                                                        escritura.Close();
                                                                                        int cantidad = Int32.Parse(elementos3[b + 4]);
                                                                                        cantidad = cantidad - 1;
                                                                                        elementos3[b + 4] = Convert.ToString(cantidad);
                                                                                        StreamWriter escritura3 = File.CreateText(ruta3);
                                                                                        for (int r = 0; r < elementos3.Length; r++)
                                                                                        {
                                                                                            escritura3.WriteLine(elementos3[r].Trim());
                                                                                        }
                                                                                        escritura3.Close();
                                                                                        elementos4[a + 1] = isbn;
                                                                                        StreamWriter escritura4 = File.CreateText(ruta4);
                                                                                        for (int y = 0; y < elementos4.Length; y++)
                                                                                        {
                                                                                            escritura4.WriteLine(elementos4[y].Trim());
                                                                                        }
                                                                                        escritura4.Close();
                                                                                        Console.WriteLine("Se ha modificado el ISBN del libro");
                                                                                        break;


                                                                                    }
                                                                                }
                                                                            }

                                                                        }

                                                                    }
                                                                    break;
                                                                }
                                                                
                                                                else
                                                                {
                                                                    control = 0;
                                                                }
                                                                if (control == 0)
                                                                {
                                                                    Console.WriteLine("Ya tienes el maximo de libros prestados, devuelve uno para seguir solicitando");
                                                                    Console.WriteLine(contenido4);
                                                                    break;
                                                                }


                                                                break;
                                                            }
                                                        case 3: // devolucion de un libro 
                                                            {
                                                                Console.WriteLine("Devolucion de un libro");
                                                                Console.WriteLine("Que libro quieres devolver ( Favor de escribir el ISBN )");
                                                                string nisbn = Console.ReadLine();
                                                                for (int a = 0; a < elementos4.Length; a = a + 4)
                                                                {
                                                                    if (elementos4[a + 1].Trim().Equals(nisbn))
                                                                    {

                                                                        for (int o = 0; o < elementos3.Length; o = o + 6)
                                                                        {
                                                                            if (nisbn.Equals(elementos3[o].Trim()))
                                                                            {
                                                                                int libros = Int32.Parse(elementos[x + 3]);
                                                                                if (libros == 0)
                                                                                {
                                                                                    Console.WriteLine("No hay libros que devolver");
                                                                                    break;
                                                                                }
                                                                                else
                                                                                {
                                                                                    int prestamos = Int32.Parse(elementos[x + 3]);
                                                                                    prestamos = prestamos - 1;
                                                                                    elementos[x + 3] = Convert.ToString(prestamos);
                                                                                    StreamWriter escritura = File.CreateText(ruta);
                                                                                    for (int t = 0; t < elementos.Length; t++)
                                                                                    {
                                                                                        escritura.WriteLine(elementos[t].Trim());
                                                                                    }
                                                                                    escritura.Close();
                                                                                    int cantidad = Int32.Parse(elementos3[o + 4]);
                                                                                    cantidad = cantidad + 1;
                                                                                    elementos3[o + 4] = Convert.ToString(cantidad);
                                                                                    StreamWriter escritura3 = File.CreateText(ruta3);
                                                                                    for (int r = 0; r < elementos3.Length; r++)
                                                                                    {
                                                                                        escritura3.WriteLine(elementos3[r].Trim());
                                                                                    }
                                                                                    escritura3.Close();
                                                                                    elementos4[a + 1] = "disponible";
                                                                                    StreamWriter escritura4 = File.CreateText(ruta4);
                                                                                    for (int y = 0; y < elementos4.Length; y++)
                                                                                    {
                                                                                        escritura4.WriteLine(elementos4[y].Trim());
                                                                                    }
                                                                                    escritura4.Close();
                                                                                   
                                                                                    Console.WriteLine("La devolucion ya fue hecha");
                                                                                    break;
                                                                                }

                                                                            }
                                                                        }
                                                                    }
                                                                    if (elementos4[a + 2].Trim().Equals(nisbn))
                                                                    {

                                                                        for (int o = 0; o < elementos3.Length; o = o + 6)
                                                                        {
                                                                            if (nisbn.Equals(elementos3[o].Trim()))
                                                                            {
                                                                                int libros = Int32.Parse(elementos[x + 3]);
                                                                                if (libros == 0)
                                                                                {
                                                                                    Console.WriteLine("No hay libros que devolver");
                                                                                    break;
                                                                                }
                                                                                else
                                                                                {
                                                                                    int prestamos = Int32.Parse(elementos[x + 3]);
                                                                                    prestamos = prestamos - 1;
                                                                                    elementos[x + 3] = Convert.ToString(prestamos);
                                                                                    StreamWriter escritura = File.CreateText(ruta);
                                                                                    for (int t = 0; t < elementos.Length; t++)
                                                                                    {
                                                                                        escritura.WriteLine(elementos[t].Trim());
                                                                                    }
                                                                                    escritura.Close();
                                                                                    int cantidad = Int32.Parse(elementos3[o + 4]);
                                                                                    cantidad = cantidad + 1;
                                                                                    elementos3[o + 4] = Convert.ToString(cantidad);
                                                                                    StreamWriter escritura3 = File.CreateText(ruta3);
                                                                                    for (int r = 0; r < elementos3.Length; r++)
                                                                                    {
                                                                                        escritura3.WriteLine(elementos3[r].Trim());
                                                                                    }
                                                                                    escritura3.Close();
                                                                                    elementos4[a + 1] = nisbn;
                                                                                    StreamWriter escritura4 = File.CreateText(ruta4);
                                                                                    for (int y = 0; y < elementos4.Length; y++)
                                                                                    {
                                                                                        escritura4.WriteLine(elementos4[y].Trim());
                                                                                    }
                                                                                    escritura4.Close();
                                                                                    Console.WriteLine("La devolucion ya fue hecha");
                                                                                    break;
                                                                                }

                                                                            }
                                                                        }
                                                                    }
                                                                    if (elementos4[a + 3].Trim().Equals(nisbn))
                                                                    {

                                                                        for (int o = 0; o < elementos3.Length; o = o + 6)
                                                                        {
                                                                            if (nisbn.Equals(elementos3[o].Trim()))
                                                                            {
                                                                                int libros = Int32.Parse(elementos[x + 3]);
                                                                                if (libros == 0)
                                                                                {
                                                                                    Console.WriteLine("No hay libros que devolver");
                                                                                    break;
                                                                                }
                                                                                else
                                                                                {
                                                                                    int prestamos = Int32.Parse(elementos[x + 3]);
                                                                                    prestamos = prestamos - 1;
                                                                                    elementos[x + 3] = Convert.ToString(prestamos);
                                                                                    StreamWriter escritura = File.CreateText(ruta);
                                                                                    for (int t = 0; t < elementos.Length; t++)
                                                                                    {
                                                                                        escritura.WriteLine(elementos[t].Trim());
                                                                                    }
                                                                                    escritura.Close();
                                                                                    int cantidad = Int32.Parse(elementos3[o + 4]);
                                                                                    cantidad = cantidad + 1;
                                                                                    elementos3[o + 4] = Convert.ToString(cantidad);
                                                                                    StreamWriter escritura3 = File.CreateText(ruta3);
                                                                                    for (int r = 0; r < elementos3.Length; r++)
                                                                                    {
                                                                                        escritura3.WriteLine(elementos3[r].Trim());
                                                                                    }
                                                                                    escritura3.Close();
                                                                                    elementos4[a + 1] = nisbn;
                                                                                    StreamWriter escritura4 = File.CreateText(ruta4);
                                                                                    for (int y = 0; y < elementos4.Length; y++)
                                                                                    {
                                                                                        escritura4.WriteLine(elementos4[y].Trim());
                                                                                    }
                                                                                    escritura4.Close();
                                                                                    Console.WriteLine("La devolucion ya fue hecha");
                                                                                    break;
                                                                                }

                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                Console.WriteLine("No existe opcion");
                                                                break;
                                                            }
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Contraseña incorrecta");
                                                    break;
                                                }
                                            }

                                        }

                                        break;
                                    }
                                case 2://Registro 
                                    {
                                        StreamReader lectura = File.OpenText(ruta);
                                        String contenido = lectura.ReadToEnd();
                                        lectura.Close();
                                        string[] elementos = contenido.Split('\n');
                                        Console.WriteLine("Ingresa tu nuevo usuaio");
                                        string usuario = Console.ReadLine();
                                        byte status = 0;
                                        //Validacion para saber si el usuario no existe 
                                        for (int a = 0; a < elementos.Length; a = a + 4)
                                        {
                                            if (usuario.Equals(elementos[a].Trim()))
                                            {
                                                Console.WriteLine("No puedes usar este nombre de usuario debido a que ya existe alguien mas registrado asi");
                                                break;
                                            }
                                            else
                                            {
                                                status = 0;
                                            }
                                            if (status == 0)
                                            {
                                                StreamWriter escritura = File.AppendText(ruta);
                                                escritura.WriteLine(usuario);
                                                Console.WriteLine("Ingresa tu nueva contraseña");
                                                string contraseña = Console.ReadLine();
                                                escritura.WriteLine(contraseña);
                                                Console.WriteLine("Ingresa un correo electronico");
                                                string correo = Console.ReadLine();
                                                escritura.WriteLine(correo);
                                                int prestamos = 0;
                                                escritura.WriteLine(prestamos);
                                                escritura.Close();
                                                Console.WriteLine("Te has registrado exitosamente");
                                                StreamWriter escritura4 = File.AppendText(ruta4);
                                                escritura4.WriteLine(usuario);
                                                escritura4.WriteLine("disponible");
                                                escritura4.WriteLine("disponible");
                                                escritura4.WriteLine("disponible");
                                                escritura4.Close();
                                                break;
                                            }
                                        }

                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Esta opcion no existe");
                                        break;
                                    }
                            }

                            break;
                        }
                    case 2://Administrador 
                        {
                            Console.Clear();
                            Console.WriteLine("Bienvenido a la seccion de administradores");
                            StreamReader lectura2 = File.OpenText(ruta2);
                            String contenido2 = lectura2.ReadToEnd();
                            lectura2.Close();
                            string[] elementos2 = contenido2.Split('\n');
                            Console.WriteLine("Por favor ingresa el usuario del administrador");
                            string usuarioadmin = Console.ReadLine();

                            for (int xy = 0; xy < elementos2.Length; xy = xy + 0)
                            {
                                if (elementos2[xy] == usuarioadmin)
                                {
                                    control = 0;
                                    StreamReader lectura3 = File.OpenText(ruta3);
                                    String contenido3 = lectura3.ReadToEnd();
                                    lectura3.Close();
                                    string[] elementos3 = contenido3.Split('\n');
                                    Console.Clear();
                                    Console.WriteLine("Has iniciado sesion correctamente");
                                    Console.WriteLine("¿Que deseas hacer?\n1.-Moficar la informacion\n2.-Ver informacion\n3.-Dar de alta un libro\n4.-Dar de baja");
                                    byte menu3 = byte.Parse(Console.ReadLine());
                                    switch (menu3)
                                    {
                                        case 1:
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Modificar informacion");
                                                Console.WriteLine("Ingrese el ISBN del libro que desea modificar");
                                                string isbn = Console.ReadLine();
                                                for (int c = 0; c < elementos3.Length; c = c + 6)
                                                {
                                                    if (isbn.Equals(elementos3[c].Trim()))
                                                    {
                                                        Console.WriteLine("Que informacion deseas modificar\n1.-ISBN\n2.-Titulo del libro\n3.-Descripcion\n4.-Genero\n5.-Cantidad en existencia\n6.-Ubicacion");
                                                        byte menu4 = byte.Parse(Console.ReadLine());
                                                        switch (menu4)
                                                        {
                                                            case 1:
                                                                {
                                                                    Console.WriteLine("Modificacion del ISBN");
                                                                    Console.WriteLine("Cual sera el nuevo ISBN del libro");
                                                                    string nisbn = Console.ReadLine();
                                                                    elementos3[c] = nisbn;
                                                                    StreamWriter escritura = File.CreateText(ruta3);
                                                                    for (int y = 0; y < elementos3.Length; y++)
                                                                    {
                                                                        escritura.WriteLine(elementos3[y].Trim());
                                                                    }
                                                                    escritura.Close();
                                                                    Console.WriteLine("Se ha modificado el ISBN del libro");
                                                                    break;
                                                                }
                                                            case 2:
                                                                {
                                                                    Console.WriteLine("Titulo del libro");
                                                                    Console.WriteLine("Cual sera el nuevo titulo del libro");
                                                                    string ntitulo = Console.ReadLine();
                                                                    elementos3[c + 1] = ntitulo;
                                                                    StreamWriter escritura = File.CreateText(ruta3);
                                                                    for (int y = 0; y < elementos3.Length; y++)
                                                                    {
                                                                        escritura.WriteLine(elementos3[y].Trim());
                                                                    }
                                                                    escritura.Close();
                                                                    Console.WriteLine("Se ha modificado el titulo del libro");
                                                                    break;
                                                                }
                                                            case 3:
                                                                {
                                                                    Console.WriteLine("Descripcion del libro");
                                                                    Console.WriteLine("Cual sera la nueva descripcion del libro");
                                                                    string ndescripcion = Console.ReadLine();
                                                                    elementos3[c + 2] = ndescripcion;
                                                                    StreamWriter escritura = File.CreateText(ruta3);
                                                                    for (int y = 0; y < elementos3.Length; y++)
                                                                    {
                                                                        escritura.WriteLine(elementos3[y].Trim());
                                                                    }
                                                                    escritura.Close();
                                                                    Console.WriteLine("Se ha modificado la descripcion del libro");
                                                                    break;
                                                                }
                                                            case 4:
                                                                {
                                                                    Console.WriteLine("Genero del libro");
                                                                    Console.WriteLine("Cual sera el nuevo genero del libro");
                                                                    string ngenero = Console.ReadLine();
                                                                    elementos3[c + 3] = ngenero;
                                                                    StreamWriter escritura = File.CreateText(ruta3);
                                                                    for (int y = 0; y < elementos3.Length; y++)
                                                                    {
                                                                        escritura.WriteLine(elementos3[y].Trim());
                                                                    }
                                                                    escritura.Close();
                                                                    Console.WriteLine("Se ha modificado el genero del libro");
                                                                    break;
                                                                }
                                                            case 5:
                                                                {
                                                                    Console.WriteLine("Cantidad en existencia");
                                                                    Console.WriteLine("Ingrese la cantidad en existencia de los libros");
                                                                    int cantidad = int.Parse(Console.ReadLine());
                                                                    elementos3[c + 4] = Convert.ToString(cantidad);
                                                                    StreamWriter escritura = File.CreateText(ruta3);
                                                                    for (int y = 0; y < elementos3.Length; y++)
                                                                    {
                                                                        escritura.WriteLine(elementos3[y].Trim());
                                                                    }
                                                                    escritura.Close();
                                                                    Console.WriteLine("Se ha modificado la cantidad en existencia del libro ");

                                                                    break;
                                                                }
                                                            case 6:
                                                                {
                                                                    Console.WriteLine("Ubicacion");
                                                                    Console.WriteLine("Cual sera la nueva ubicacion del libro");
                                                                    string nubicacion = Console.ReadLine();
                                                                    elementos3[c + 5] = nubicacion;
                                                                    StreamWriter escritura = File.CreateText(ruta3);
                                                                    for (int y = 0; y < elementos3.Length; y++)
                                                                    {
                                                                        escritura.WriteLine(elementos3[y].Trim());
                                                                    }
                                                                    escritura.Close();
                                                                    Console.WriteLine("Se ha modificado la nueva ubicacion libro");
                                                                    break;
                                                                }
                                                            default:
                                                                {
                                                                    Console.WriteLine("Esta opcion no existe");
                                                                    break;
                                                                }

                                                        }

                                                    }
                                                    else
                                                    {
                                                        control = 0;
                                                    }
                                                    if (control == 0)
                                                    {
                                                        Console.WriteLine("No existe ese isbn");
                                                        break;

                                                    }
                                                }
                                                break;

                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Ver informacion");
                                                Console.WriteLine(contenido3);
                                                Console.ReadKey();
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.WriteLine("Dar de alta un libro");
                                                StreamWriter escritura = File.AppendText(ruta3);
                                                Console.WriteLine("Ingresa el ISBN del libro");
                                                string isbn = Console.ReadLine();
                                                escritura.WriteLine(isbn);
                                                Console.WriteLine("Ingresa el titulo del libro");
                                                string titulo = Console.ReadLine();
                                                escritura.WriteLine(titulo);
                                                Console.WriteLine("Ingresa la descripcion del libro");
                                                string descripcion = Console.ReadLine();
                                                escritura.WriteLine(descripcion);
                                                Console.WriteLine("Ingresa el genero del libro");
                                                string genero = Console.ReadLine();
                                                escritura.WriteLine(genero);
                                                Console.WriteLine("Ingresa la cantidad en existencia");
                                                int existencia = int.Parse(Console.ReadLine());
                                                escritura.WriteLine(existencia);
                                                Console.WriteLine("Ingresa el estante donde se encuentra localizado");
                                                string estante = Console.ReadLine();
                                                escritura.WriteLine(estante);
                                                escritura.Close();
                                                Console.WriteLine("El libro se ha dado de alta");
                                                break;
                                            }
                                        case 4:
                                            {
                                                Console.WriteLine("Dar de baja");
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Esta opcion no existe");
                                                break;
                                            }
                                    }
                                }

                                else
                                {
                                    Console.WriteLine("Clave incorrrecta");
                                    break;
                                }
                            }
                            break;
                        }
                }
                Console.WriteLine("Deseas volver al menu principal\n0.-Si\n1.-No");
                opcion = byte.Parse(Console.ReadLine());
            }
            while (opcion == 0);
        }
    }
}