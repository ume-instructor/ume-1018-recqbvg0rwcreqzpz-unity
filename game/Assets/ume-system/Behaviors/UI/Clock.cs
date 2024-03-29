using UnityEngine;
using UnityEngine.UI;

namespace UME
{
	
	public class Clock: UIData
	{
		
		public bool countDown = true;
		public int seconds = 60;
		public int maxValue = 0;
		private float value = 0;

		public override void setType(){
			boardType = UIBoardType.time;
		}
		// Use this for initialization
		public override void Initialize(){
			if (uiOffset != Vector2.zero)
				uiText.GetComponentInParent<RectTransform> ().anchoredPosition = uiOffset;
			if (uiControl != null)
				uiControl.UIDataSources.Add (this);
			maxValue = Mathf.Max (0, maxValue);
			value = 0;
			if (countDown) 
				//add one for init time
				value = Mathf.Max(0,seconds+1f);
			UpdateText ();
		}

		// Update is called once per frame
		void Update () {
			float sign = 1.0f;
			if (countDown)
				sign = -1.0f;
			float t = Time.deltaTime * sign;
			UpdateValue(t);
		}
		public override void UpdateValue(int val){
			UpdateValue ((float)val);
		}
		public override void UpdateValue(float val){
			if (maxValue <= 0)
				value = Mathf.Max (value + (float)val, 0.0f);
			else
				value = Mathf.Clamp(value + (float)val, 0.0f, (float)maxValue);
			UpdateText ();
			if (value <= 0 && uiControl != null)
				uiControl.UpdateGameMessage (GameState.lose, gameObject);
		}
	
		public override void UpdateText () { 
			if (uiText != null) {
				int hours = 0;
				int	minutes = ((int)value % 3600) / 60;
				int secs = ((int)value % 3600) % 60;
				if (hours > 0)
					uiText.text = string.Format ("{0} {1}:{2}:{3}", label, hours, minutes, secs);
				else if (minutes > 0)
					uiText.text = string.Format ("{0} {1:D2}:{2:D2}", label, minutes, secs);
				else
					uiText.text = string.Format ("{0} {1:D2}", label, secs);
			}
		}
	

	}
}
