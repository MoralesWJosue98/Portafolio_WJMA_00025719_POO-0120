package com.WJMA.x00025719;

public class Persona {
    private String sexo;
    private int edad;

    public Persona(){
    }
    public Persona(String Sexo, int Edad){
        sexo = Sexo;
        edad = Edad;
    }

    public String getSexo(){
        return sexo;
    }
    public void setSexo(String Sexo){
        sexo = Sexo;
    }

    public int getEdad(){
        return edad;
    }
    public void setEdad(int Edad){
        edad = Edad;
    }

    public void gender(){
        System.out.println("El genero de la persona es: " + " " + sexo);
    }
    public void age(){
        System.out.println("La edad de la persona es: " + " " + edad);
    }






}
