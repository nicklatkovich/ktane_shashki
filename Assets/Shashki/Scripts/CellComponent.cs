﻿using UnityEngine;

public class CellComponent : MonoBehaviour {
	public Renderer Renderer;
	public KMSelectable Selectable;

	private bool _highlighted = false;
	public bool highlighted { get { return _highlighted; } private set { _highlighted = value; UpdateHighlight(); } }

	private bool _selected = false;
	public bool selected { get { return _selected; } set { _selected = value; UpdateHighlight(); } }

	private GameObject highlight;

	private void Start() {
		Selectable.OnHighlight += () => { highlighted = true; };
		Selectable.OnHighlightEnded += () => { highlighted = false; };
	}

	private void UpdateHighlight() {
		if (highlight == null) {
			if (Selectable.Highlight.transform.childCount < 1) return;
			highlight = Selectable.Highlight.transform.GetChild(0).gameObject;
		}
		highlight.SetActive(highlighted || selected);
	}
}
