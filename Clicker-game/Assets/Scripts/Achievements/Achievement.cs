using UnityEngine;
using UnityEngine.UI;

public abstract class Achievement {
	public string name { get; protected set; }
	public string description { get; protected set; }
	public int currentLevel { get; protected set; }
	public double currentValue { get; protected  set; }
	public double[] valuesTable { get; protected  set; }
	public float progress { get; protected  set; }
	public bool revealed { get; protected  set; }
	public GameObject aPanel { get; set; }
	public Image aProgressBar { get; set; }

	public Achievement(int id, string name, string description, bool revealed, GameObject aPanel, Image aProgressBar) {
		this.name = name;
		this.description = description;
		this.currentLevel = 0;
		this.currentValue = 0;
		this.valuesTable = valuesTable;
		this.progress = 0.0f;
		this.revealed = revealed;
		this.aPanel = aPanel;
		this.aProgressBar = aProgressBar;
	}

	public void OnMouseOver(ToolTip tt) {
		tt.TurnToolTipOn (
			aPanel,
			name,
			currentLevel.ToString() + "/" + valuesTable.Length.ToString(),
			description + " " + progress.ToString("P0")
		);
	}

	public void CalculateCurrentLevel() {
		int i = 0;
		for (; i < valuesTable.Length; i++) {
			if (currentValue < valuesTable[i]) {
				break;
			}
		}
		currentLevel = i;
	}

	public void CalculateProgress() {
		progress = (currentLevel >= valuesTable.Length) ? 100.0f : (float)(currentValue / valuesTable[currentLevel]);
	}

	public void UpdateProgressBar() {
		aProgressBar.fillAmount = progress;
	}

	public abstract void UpdateAchievement();
}
