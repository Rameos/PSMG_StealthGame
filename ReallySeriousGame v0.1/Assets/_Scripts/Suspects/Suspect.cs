using UnityEngine;
using System.Collections;

public class Suspect : MonoBehaviour
{

    private const string name_barkeeper = "Karl";
    private const string name_doctor = "Grace Turner";
    private const string name_junkie = "Eric Pommeroy";
    private const string name_investor = "Bryan Woodsmith";
    private const string name_wife = "Alexandra Woodsmith";
    private const string name_personnel = "Suzanne";
    private const string name_detective = "James 'Jimmy' Royce";

    private const int age_barkeeper = 36;
    private const int age_doctor = 32;
    private const int age_junkie = 40;
    private const int age_investor = 54;
    private const int age_wife = 35;
    private const int age_personnel = 44;
    private const int age_detective = 31;

    private const string details_barkeeper =
        "Sehr professioneller Mixologe, der die Kunst den perfekten Drink zu mischen gemeistert hat. Da er sehr gelassen und vertrauenswürdig wirkt bekommt er so einiges von den Passagieren mit. Sein Bruder, der ihm sehr nahe stand, war einer der Patienten, die im Stadtklinikum gestorben sind und da er ihn dort davor regelmäßig besucht hat, hat er auch einiges gehört und weiß, dass nicht alles ganz richtig abgelaufen ist.";
    private const string details_doctor =
        "Zur großen Schwester aufblickend hat Grace schon sehr jung angefangen über Medizin zu lernen, damit sie eines Tages auch Menschen helfen kann. Ihre Schwester leitete nämlich das größte Klinikum der Stadt bei der sie auch angefangen hat zu praktizieren. So ist sie schnell zu einer Ärztin geworden, die fast genauso brilliant war, wie ihre Schwester. Als das Klinikum bei der Entwicklung eines neuen Medikaments finanzielle Unterstützung von einem Investor erhielt ahnte die leitende Ärztin zunächst nichts von seinen tatsächlichen Intentionen. Aber schon bald merkte sie, dass sie immer mehr die Kontrolle verlor, bis zu dem Punkt als das Medikament fertig war und sie es terminal kranken Patienten nicht verabreichen durfte und es verheimlichen musste. Als sie widersprach und es raus kam, wurde sie und das Klinikum für den Tod der Patienten verantwortlich gemacht. Das konnte sie nicht ertragen und beging Selbstmord durch erhängen. All dies traf Grace schwer und sie, die einst geschworen hat Menschen zu heilen, schwor nun ihre Schwester zu rächen und diese Ungerechtigkeit aufzudecken.";
    private const string details_junkie =
        "Ein Drogensüchtiger, der nicht selten mal zu weit geht, um das zu bekommen was er will.";
    private const string details_investor =
        "Von außen ein wohlhabender Investor, von innen eine Person, die zu allem in der Lage ist, um ihre Geldgier zu befriedigen.";
    private const string details_wife =
        "Loyale Frau, die ihren Mann beisteht, obwohl er ihr nicht immer alles erzählt und vieles verheimlicht. Sie ist intelligent genug um Zusammenhänge zu erkennen, dass ihr Mann nicht immer legal handelt, aber stellt nicht zu viele Fragen um sich selbst zu schützen.";
    private const string details_personnel =
        "Suzanne arbeitet schon die Hälfte ihres Lebens auf SS Sophia aufgrund ihrer Gründlichkeit, Freundlichkeit und Zuverlässigkeit. Sie ist u.a. auch für die Einweisung neuer Mitarbeiter zuständig. Da sie schon so lange auf diesem Schiff arbeitet, kennt sie natürlich auch die Stammpassagiere, nicht nur durch Unterhaltungen sondern auch weil sie ihre Zimmer sehr 'gründlich aufräumt'. Folglich weiß sie sehr viel über dieses Schiff und ihre Passagiere und sie unterhält sich gerne und viel.";
    private const string details_detective =
        "Ehemaliger Mordkommissar. Mit unvergleichbarem Eifer und Ehrgeiz hat sich Jimmy zum jüngsten Mordkommissar hochgearbeitet. Jedoch ist ihm aufgefallen, dass sich keiner seiner Kollegen gleich viel bemüht, Fälle zu lösen wie er. Im Gegenteil, während sich seine Kollegen mit der erstbesten Lösung zufrieden geben und den Fall schnellstmöglich abschließen wollen, besteht er darauf weiterzuarbeiten bis er die Wahrheit gefunden hat. So hat er mit seinem Scharfsinn der örtlichen Polizei nicht nur dabei geholfen schwierige Fälle zu lösen, sondern auch unbeliebt gemacht, da er mehr Arbeit für seine faulen Kollegen sorgt. \n \n Verärgert darüber, dass seine Bemühungen nicht geschätzt sondern gar missbilligt werden entscheidet er sich als Mordkommissar zurückzutreten. Jedoch kann er mit dem Wissen, über die Einstellung seiner ehemaligen Kollegen bei der Polizei, nicht ohne gutes Gewissen einfach aufhören. Folglich entscheidet er sich als Privatdetektiv tätig zu werden um die Wahrheiten aufzudecken, die andere nicht haben wollen.";

    private const int state_save = 0;
    private const int state_default = 1;
    private const int state_nervous = 2;
    private const int state_suspicious = 3;
    private const int state_angry = 4;

    private SuspectObject barkeeper, doctor, junkie, investor, wife, personnel, detective;

    // Use this for initialization
    void Start()
    {
        barkeeper = new SuspectObject(name_barkeeper, age_barkeeper, true, details_barkeeper, );
        doctor = new SuspectObject(name_doctor, age_doctor, false, details_doctor);
        junkie = new SuspectObject(name_junkie, age_junkie, true, details_junkie);
        investor = new SuspectObject(name_investor, age_investor, true, details_investor);
        wife = new SuspectObject(name_wife, age_wife, false, details_wife);
        personnel = new SuspectObject(name_personnel, age_personnel, false, details_personnel);
        detective = new SuspectObject(name_detective, age_detective, true, details_detective);

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class SuspectObject
{
    private int age;
    private string name;
    private string details;
    private string gender;
    public SuspectObject(string name, int age, bool gender, string details)
    {
        this.name = name;
        this.age = age;
        this.details = details;
        if (gender)
        {
            this.gender = "male";
        }
        else
        {
            this.gender = "female";
        }
    }

    public int getAge()
    {
        return age;
    }
    public string getName()
    {
        return name;
    }

    public string getDetails()
    {
        return details;
    }

}
