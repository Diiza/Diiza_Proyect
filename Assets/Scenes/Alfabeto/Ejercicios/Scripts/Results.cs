
public class Results
{
    private string textName;
    private string resultQ;
    

    public Results(string textName, bool isCorrect){
        this.textName=textName;
        statusAnswer(isCorrect);
    }

    private void  statusAnswer(bool isCorrect){
        if(isCorrect==true){
            resultQ="✓";
        }else{
            resultQ="x";
        }
    }

    public string getName(){
        return textName;
    }    

    public string getResult(){
        return resultQ;
    }
    
}
