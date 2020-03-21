package com.WJMA.x00025719;

public class Main {

    public static void main(String[] args) {
	Laptop lap = new Laptop("IntelliJ IDEA", "DELL");
	lap.abrirPrograma();
	lap.setMarcaCompu("DELL");
	lap.setNombrePrograma("IntelliJ IDEA");
	lap.cerrarPrograma();
	System.out.println("Proceso terminado de: " + lap.getMarcaCompu());
	System.out.println("Proceso terminado de programa: " + lap.getNombrePrograma());

	System.out.println("\n");

	Persona person = new Persona("Masculino", 19);
	person.gender();
	person.age();
	person.setEdad(19);
	person.setSexo("Masculino");
	System.out.println("Genero: " + " " + person.getSexo());
	System.out.println("Edad: " + " " + person.getEdad() );

	}

}
