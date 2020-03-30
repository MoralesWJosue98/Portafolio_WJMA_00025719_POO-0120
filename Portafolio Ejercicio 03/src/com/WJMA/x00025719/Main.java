package com.WJMA.x00025719;
import java.util.Scanner;
import java.util.ArrayList;

public class Main {
    static Scanner scan = new Scanner(System.in);
    static ArrayList<Libro> libro = new ArrayList<>();
    public static void main(String[] args) {
    byte op =0;


    do{
        menu(); op = scan.nextByte(); scan.nextLine();
        switch (op){
            case 1:
                AggLibro();
                break;
            case 2:
                System.out.println(libro.toString());
                    break;
            case 0:
                System.out.println("Saliendo...");
                break;
            default:
                System.out.println("Ingrese una opcion valida!");
                break;

        }


        }while(op != 0);





    }

    public static void menu(){
        System.out.print("1. Agregar libro\n2. Consultar libros\n0. Salir\n");
    }

    public static void AggLibro(){
        String nombre = null; int paginas = 0;
        System.out.print("Ingrese el nombre del libro:"); nombre = scan.nextLine();
        System.out.print("Ingrese el numero de paginas:"); paginas = scan.nextInt(); scan.nextLine();
        Libro libro1 = new Libro(paginas, nombre);
        libro.add(new Libro(paginas, nombre));
        System.out.print("Agregando el libro..." + libro1.getNombre() + "\nNumero de paginas: " + libro1.getPaginas()+"\n" +
                "ISBN... " + libro1.getISBN()+"\n");

    }

}