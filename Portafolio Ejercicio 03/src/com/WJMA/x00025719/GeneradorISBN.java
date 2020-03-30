package com.WJMA.x00025719;

public class GeneradorISBN {
    private static int contador = 0;

    public GeneradorISBN() {
    }

    public static int nuevoISBN(){
        contador ++;
        return contador;
    }

}
