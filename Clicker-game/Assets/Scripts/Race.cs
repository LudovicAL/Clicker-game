using System.Collections.Generic;

public class Race {
	public string name { get; protected set; }
	public string description { get; protected set; }
	public List<Construction> constructions { get; protected set; }
	public Ability[] abilities { get; protected set; }

	public Race(string name, string description, List<Construction> constructions, Ability[] abilities) {
		this.name = name;
		this.description = description;
		this.constructions = constructions;
		this.abilities = abilities;
	}
}
