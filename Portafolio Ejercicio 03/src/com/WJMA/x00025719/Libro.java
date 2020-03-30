package com.WJMA.x00025719;

public class Libro {
    private int ISBN;
    private int paginas;
    private String nombre;


    @Override
    public String toString() {
        return "Libro: " + nombre + "\n" + "Paginas: " + paginas + "\n" + "ISBN: " + ISBN + "\n";
    }

    public Libro(int paginas, String nombre) {
        this.paginas = paginas;
        this.nombre = nombre;
        ISBN = GeneradorISBN.nuevoISBN();
    }

    public int getISBN() {
        return ISBN;
    }

    public int getPaginas() {
        return paginas;
    }

    public String getNombre() {
        return nombre;
    }
}
