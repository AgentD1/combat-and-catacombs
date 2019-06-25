package tech.jaboc.combatcatacombs;

import tech.jaboc.combatcatacombs.parsing.CommandParser;

import java.util.Scanner;

public class Game {
	public Game() {

	}

	public void Play() {
		boolean quitting = false;
		Scanner in = new Scanner(System.in);
		while (!quitting) {
			String input = in.nextLine();
			quitting = CommandParser.Parse(input);
		}
		System.exit(0);
	}
}
