public class RouletteButton {
	private int currentItem;
	private string[] captions;
	private int[] quantities;


	public RouletteButton(string[] captionsArray, int[] quantitiesArray) {
		this.currentItem = 0;
		this.captions = captionsArray;
		this.quantities = quantitiesArray;
	}

	//Moves the roulette to its next item
	public void MoveToNextItem() {
		currentItem += 1;
		if (currentItem >= captions.Length || currentItem >= quantities.Length) {
			currentItem = 0;
		}
	}

	//Properties
	public string Caption {
		get {
			return captions[currentItem];
		}
	}
		
	public int Quantity {
		get {
			return quantities[currentItem];
		}
	}
}
