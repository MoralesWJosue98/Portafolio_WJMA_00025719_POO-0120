package com.WJMA.x00025719;

public class Libro {
    private String ISBN, nombreL;
    private int paginas;


    public Libro(String pNombre, String pISBN, int pPaginas) {
        nombreL = pNombre;
        ISBN = pISBN;
        paginas = pPaginas;
    }


    public String getISBN() {
        return ISBN;
    }

    public int getPaginas() {
        return paginas;
    }

    public String getNombreL() {
        return nombreL;
    }

    @Override
    public String toString() {
        return ISBN + ":" + nombreL + "(" + paginas + ")";
    }
}
