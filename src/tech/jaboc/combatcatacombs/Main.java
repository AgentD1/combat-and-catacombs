package tech.jaboc.combatcatacombs;

import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		System.out.println("This is a test");
		System.out.print("Enter your name: ");
		String name = in.nextLine().toLowerCase();
		if(name.equals("jacob")) {
			System.out.println("Greetings Jacob, good to see you!");
		} else if(name.equals("james")) {
			System.out.println("Sup James, nice to see you!");
		} else {
			System.out.println("Hi, " + name);
		}
	}
}
