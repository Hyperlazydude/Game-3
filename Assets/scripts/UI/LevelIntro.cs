using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "intro", menuName = "Level/Create Intro", order = 0)]
public class LevelIntro : ScriptableObject
{
    public DialogueLine[] introDialogue;
    
    private float time;
    public float Time
    {
        get
        {
            if (this.time < 0)
                this.time = this.introDialogue.Aggregate(0f, (time, line) => time + line.transitionTime + line.dialogueTime);
            return this.time;
        }
    }
    
    public LevelIntro()
    {
        this.time = -1;
    }

    public IEnumerator PlayIntro(Dictionary<string, Transform> transformMap, Dictionary<string, string> nameMap)
    {
        if (this.introDialogue.Length > 0) {

            CameraMovement camera = CameraMovement.Instance;
            Dialogue dialogue = Dialogue.Instance;
            PlayerManager playerManager = PlayerManager.Instance;

            DialogueLine currentLine;
            
            for (int i = 0; i < this.introDialogue.Length; i++)
            {
                currentLine = this.introDialogue[i];
                
                camera.MoveToPoint(transformMap[currentLine.trackingID].position, currentLine.transitionTime);
                yield return new WaitForSeconds(currentLine.transitionTime);

                dialogue.Show(nameMap[currentLine.nameID], currentLine.dialogueLine);
                yield return new WaitForSeconds(currentLine.dialogueTime);

                dialogue.Hide();
            }
        }
    }
    
}