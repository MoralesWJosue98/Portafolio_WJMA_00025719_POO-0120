package com.WJMA.x00025719;
public class Laptop{
    private String nombrePrograma;
    private String marcaCompu;

    public Laptop(){
    }
    public Laptop(String NombrePrograma, String MarcaCompu){
        nombrePrograma = NombrePrograma;
        marcaCompu = MarcaCompu;
    }

    public String getNombrePrograma(){
        return  nombrePrograma;
    }
    public void setNombrePrograma(String NombrePrograma){
        nombrePrograma = NombrePrograma;
    }

    public String getMarcaCompu(){
        return  marcaCompu;
    }
    public void setMarcaCompu(String MarcaCompu){
        marcaCompu = MarcaCompu;
    }

    public void abrirPrograma(){
        System.out.println("Computadora" + " " + marcaCompu + " abriendo... " + nombrePrograma);
        System.out.println("Se abrio el programa" + " " + nombrePrograma);
    }

    public void cerrarPrograma(){
        System.out.println("Computadora" + " " + marcaCompu + " cerrando... " + nombrePrograma);
        System.out.println("Se cerro el programa" + " " + nombrePrograma);
    }











}