  using System;
//Codé par Maxime Bachelet
//Todolist:
//brute_synthese();
// Ajoute lettre_test

class Cryptage{
  static void Main(){

    string lettre_test ="";
    Console.WriteLine("Chaine a crypter : ");
    string test= Console.ReadLine();
    Console.WriteLine("Occurence : ");
    int occu = int.Parse(Console.ReadLine());

    string autorise = (Supprime_Interdit(test));
    string crypte = Cryptage_chaine(occu,autorise);
    Console.WriteLine(crypte);
    Console.WriteLine(DeCryptage_chaine(occu,crypte));
    BruteForce(crypte);
  }

/*
  estUnChar() : fonc : bool : renvoie true si l'utilisateur a bien entré le bon charactere (y ou n) dans la fonction Brute_Force();

  Parametres:
    xChar : char : charactere testé.
  Local:

  Retour:

    valide : bool : Renvoie true si le charactere est valide.

*/
  static bool estUnChar(string xChar){
    bool valide = false;
    if(xChar.Length == 1 ) {
      if (xChar[0] == 'y' || xChar[0] == 'n') {
        valide = true;
      }
      else{
        Console.WriteLine("Veuillez saisir une reponse valide !");
      }
    }
    else {
      Console.WriteLine("Veuillez saisir une reponse valide !");
    }
    return valide;
  }


/*
  BruteForce() : fonc : string : Test toutes les combinaisons de décalage possible avec DeCryptage_chaine(decalage,xString) et demande a l'utilisateur si le message est lisible ou non.

  Parametres:
    xString : string : chaine à decrypter

  local :
    comprehensible : bool : Boolean pour boucle while
    decalage : int : Incrementateur de décalage

  retour:
    res : string : chaine decrypté validé par l'utilisateur.

*/
  static string BruteForce(string xString){

    bool comprehensible = false;
    string res = "";
    int decalage = 1;

    while(!comprehensible) {

      Console.WriteLine(res = DeCryptage_chaine(decalage,xString));
      Console.WriteLine("Le message est-il compréhensible ? : Oui:y Non:n");
      string userTest = Console.ReadLine();

      while(!estUnChar(userTest)){
        Console.WriteLine("Le message est-il compréhensible ? ( Oui:y Non:n  )");
        userTest = Console.ReadLine();
      }
      char reponse = userTest[0];

      if (reponse != 'y' && reponse != 'n') {
        while(!estUnChar(reponse.ToString())){
          Console.WriteLine("Le message est-il compréhensible ? ( Oui:y Non:n  )");
          reponse = char.Parse(Console.ReadLine());
        }

      }
      if(reponse == 'y'){
        comprehensible = true;

      }
      else{
        decalage++;
      }
    }

    return res;
    }

/*
  Supprime_Interdit() : fonc : Supprime les charactere interdit d'une Chaine

  Parametres :

    xString : string : chaine a vérifier
  Local:

    interdit : string : charactere illégaux ("*!$£&é'( -è_:;çà)\"+ù*~€œ^%ê'")
  Retour:

  Illegal : bool : renvoie true si le charactere n'est pas valide
    res : string : chaine de charactere valide

*/
  static string Supprime_Interdit(string xString){

    string interdit = "*!$£&é'( -è_:;çà)\"+ù*~€œ^%ê'0123456789";
    string res="";

    for(int i=0;i<xString.Length;i++){
      bool illegal=false;
      for(int k=0;k<interdit.Length;k++){
        if(xString[i]==interdit[k]){
          illegal = true;
        }
      }
      if(!illegal){
        res+=xString[i];
      }
    }
    return res;
}

/*
  Cryptage_chaine() : fonc : string : Crypte une chaine en ceaser avec xDecalage comme Parametres

  Parametres:
    xDecalage: int : Decalage du Caeser
    xString : string : String a crypter

  Local:

    abc : string : Alphabet francais
    posLettre : int : position en fonction de [k]

  Retour:

    res : string : chaine crypté en ceaser avec xDecalage comme deplacement


*/

  static string Cryptage_chaine(int xDecalage,string xString){

    string abc ="abcdefghijklmnopqrstuvwxyz";
    string res = "";

    for(int i=0;i<xString.Length;i++){
      for (int k=0;k<abc.Length;k++){
        if(xString[i]==abc[k]){
            {
            res += abc[(k+xDecalage)%26];
            }
        }
      }
    }
    return res;
  }

  /*
    DeCryptage_chaine() : fonc : string : Decrypte une chaine en ceaser avec un decalage connu.

    Parametres:
      xDecalage: int : Decalage du Caeser
      xString : string : String a crypter

    Local:

      abc : string : Alphabet francais


    Retour:

      res : string : chaine crypté en ceaser avec xDecalage comme deplacement


  */


  static string DeCryptage_chaine(int xDecalage, string xString){

    string abc ="abcdefghijklmnopqrstuvwxyz";
    string res = "";


    for (int i=0; i<xString.Length;i++){
      for(int k=0; k<abc.Length;k++){
        if(xString[i]==abc[k]){
          if(k-xDecalage%26 < 0) {
            res += abc[26+(k-xDecalage%26)];
          }
          else{
            res+= abc[k-xDecalage%26];
          }
        }

      }
    }
    return res;


  }


  /*
  max0cu() : fonc : char : renvoie la lettre la plus utilisé dans le mot

  Parametres :
    Xstring : string : Chaine de charactere que l'on veut tester

  Local :

    nbr_ocu : int : nbr_ocu de xString[n]
    nbr_occu_max : int : nbr_ocu trouve le plus grand
    lettre_max : char : lettre don l'occurence est la plus grande
    lettre_test : char : lettre tester occu max


  Retour:
    resChar : char : Lettre la plus utilisé dans le mot.
  */
  static char maxOcu(string xString){

    int nbr_ocu=0;
    int nbr_occu_max =0;
    char lettre_max=xString[0];
    char lettre_test;


    //Boucle pour chaque lettre
    for(int i=0;i<xString.Length;i++){
      lettre_test=xString[i];
      nbr_ocu =0;
      //Pour chaque lettre, reoboucle chaque lettre
      for(int k=0;k<xString.Length;k++){
        //Si lettre[k] est pareil que lettre_test alors occurence + 1
        if(xString[k]==lettre_test){
          nbr_ocu= nbr_ocu +1;
      //Si le nombre d'ocu est supérieur a la valeur d'occu max alors remplace celui ci par la nouvelle valeur.
        if(nbr_ocu>nbr_occu_max){
          nbr_occu_max=nbr_ocu;
          lettre_max=lettre_test;
          }
        }
      }
    }
    return lettre_max;
  }


  /*
  Nb_occurence : int : Renvoie le nombre d'occurence xChar de la chaine xString

  Parametres:
    xChar : char : Occurence a chercher
    xString : string : Chaine de charactere que l'on teste
  Local:
    i : int : Incrementeur de la boucle for.
  Retour:
    res : int : Nbr d'occurence de xChar dans Xstring.
  */


  static int Nb_occurence(char xChar,string xString){
    int res = 0;

    for(int i=0; i < xString.Length; i++){
      if(xString[i]==xChar){
        res++;
      }
    }
    return res;
  }
}
