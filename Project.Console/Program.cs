using Newtonsoft.Json;
using Project.Console;


// Google Cloud Vision API --> OCR (Optical Character Recognition) 
// Masaüstünde bulunan json dosyasının  pathini verdik.
string filePath = @"C:\Users\kaank\OneDrive\Desktop\json\json.txt";


// Okuma işlemi için Streamreadr açtık. Using garbage collectorı tetikler kodla iş bittiksen bir süre sonra ram'den temizlenir.
using (var sr = new StreamReader(filePath))
{

    // Jsonu okuduk ve ReadToEnd methodundan çıktısını string olarak aldık.
    string json = sr.ReadToEnd();
    sr.Close();

    // Gelen json verisine uygun yapıyı karşılayacak sınıflarımızı oluşturduk ve DeserializeObject işlemini yaptık.
    List<Receipt> receipts = JsonConvert.DeserializeObject<List<Receipt>>(json);



    foreach (var item in receipts)
    {
        // descriptiondaki verilen karaktere göre parçalara ayırdık ve dizeye attık.
        string[] lines = item.Description.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {

            Console.WriteLine($"{i + 1} {lines[i]}");
        }

    }   

}


Console.ReadLine();