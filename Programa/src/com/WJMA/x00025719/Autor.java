package com.WJMA.x00025719;


public class Autor {
    private String nombre, email;
    private char genero;


public Autor(String Nombre, String Email, char Genero) {
    nombre = Nombre;
    email = Email;
    genero = Genero;
    }

    public String getNombre() {
        return nombre;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public char getGenero() {
        return genero;
    }

    @Override
    public String toString() {
        return nombre + "(" + genero + "): " + email;
    }
}