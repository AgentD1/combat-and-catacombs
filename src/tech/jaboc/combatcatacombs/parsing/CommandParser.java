package tech.jaboc.combatcatacombs.parsing;

public final class CommandParser {
	private CommandParser() {
	}

	public static boolean Parse(String stringToParse) {
		System.out.println(stringToParse);
		return stringToParse.equals("quit");
	}
}
