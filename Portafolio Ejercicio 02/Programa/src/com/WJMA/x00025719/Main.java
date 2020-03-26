package com.WJMA.x00025719;
import java.util.Scanner;
import java.util.ArrayList;



public class Main {
    static Scanner scan = new Scanner(System.in);
    static ArrayList<Autor> autor = new ArrayList<>();
    static ArrayList<Libro> libro = new ArrayList<>();
    public static void main(String[] args) {
        byte op1 = 0, op2 = 0, op3 = 0;
        menu(); op1 = scan.nextByte(); scan.nextLine();
        switch (op1) {
            case 1:
            do {
                menu2(); op2 = scan.nextByte(); scan.nextLine();
                switch (op2) {
                    case 1:
                        agregarAutor();
                        break;
                    case 2:
                        quitarAutor();
                        break;
                    case 3:
                        consultarAutores();
                        break;
                    case 0:
                        System.out.println("Hasta la prooocsima");
                        break;
                    default:
                        System.out.println("Opcion invalida !");
                        break;
                }
            } while (op2 != 0);
            break;

            case 2:
                do{
                    menu3(); op3 = scan.nextByte(); scan.nextLine();
                    switch (op3){
                        case 1:
                            agregarLibro();
                            break;
                        case 2:
                            quitarLibro();
                            break;
                        case 3:
                            consultarLibros();
                            break;
                        case 0:
                            System.out.println("Hasta la prooocsima");
                            break;
                        default:
                            System.out.println("Opcion invalida !");
                            break;

                    }

                }while(op3 != 0);
                break;

            default:
                break;
        }




    }

    public static void menu(){
        System.out.println("1. Menu de autores.");
        System.out.println("2. Menu de libros.");
    }

    public static void menu2(){
        System.out.println("1. Agregar autor.");
        System.out.println("2. Quitar autor.");
        System.out.println("3. Consultar autores.");
        System.out.println("0. Salir");
    }

    public static void menu3(){
        System.out.println("1. Agregar libro.");
        System.out.println("2. Quitar libro.");
        System.out.println("3. Consultar libros.");
        System.out.println("0. Salir");
    }

    static public void agregarAutor(){
        String nombre = null, email = null; char genero = 0;
        System.out.print("Ingrese el nombre del autor:\n "); nombre= scan.nextLine();
        System.out.print("Ingrese el email del autor:\n "); email = scan.nextLine();
        System.out.print("Ingrese el genero del autor\n M: Masculino\n F: Femenino\n "); genero = scan.next().charAt(0);
        if(genero == 'M' || genero == 'F'){
            Autor pAutor = new Autor(nombre, email, genero);
            pAutor.setEmail(email);
            autor.add(new Autor(nombre, email, genero));
            System.out.print("Agregando..." + pAutor.getNombre() + "\nEmail... " + pAutor.getEmail() + "\nGenero... " + pAutor.getGenero() + "\n");
        }
        else{
            System.out.println("LOS UNICOS CARACTERES VALIDOS SON M O F!");
        }

    }

    static public void quitarAutor(){
        String nombre = null, email = null; char genero = 0;
        Autor pAutor = new Autor(nombre, email, genero);
        System.out.print("Ingrese el nombre del autor:\n"); nombre = scan.nextLine();
        String auxNombre = nombre;
        System.out.print("Eliminando el autor  " + nombre + "...\n");
        autor.removeIf(s -> s.getNombre().equals(auxNombre));
    }

    static public void consultarAutores(){
        System.out.println(autor.toString());
    }

    static public void agregarLibro(){
        String nombreL = null, ISBN = null; int paginas = 0;
        System.out.print("Ingrese el nombre del libro:\n "); nombreL = scan.nextLine();
        System.out.print("Ingrese el ISBN del libro:\n "); ISBN = scan.nextLine();
        System.out.print("Ingrese el numero de paginas:\n "); paginas = scan.nextInt(); scan.nextLine();
        Libro pLibro = new Libro(nombreL, ISBN, paginas);
        libro.add(new Libro(nombreL, ISBN,paginas));
        System.out.print("Agregando..." + pLibro.getNombreL() + "\nISBN... " + pLibro.getISBN() + "\nPaginas... " + pLibro.getPaginas() + "\n");
    }

    static public void quitarLibro(){
        String nombreL = null, ISBN = null; int paginas = 0;
        Libro pLibro = new Libro(nombreL, ISBN, paginas);
        System.out.print("Ingrese el ISBN del libro:\n"); ISBN = scan.nextLine();
        String auxISBN = ISBN;
        System.out.println("Ingrese el nombre del libro: "); nombreL = scan.nextLine();
        System.out.print("Eliminando el libro  " + nombreL + "...\n");
        libro.removeIf(s -> s.getISBN().equals(auxISBN));
    }

    static public void consultarLibros(){
        System.out.println(libro.toString());
    }
















}
