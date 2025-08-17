using Azure.Core;
using Azure.Messaging;
using Microsoft.CognitiveServices.Speech;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IBMSUBMISSION
{
    public class Messages
    {
        public string Role { get; set; }
        public object Content { get; set; }  // bisa List<ContentItem> atau string
    }
    public class Body
    {
        public List<Messages> Messages { get; set; }
        public string Project_Id { get; set; }
        public string Model_Id { get; set; }
        public int Frequency_Penalty { get; set; }
        public int Max_Tokens { get; set; }
        public int Presence_Penalty { get; set; }
        public int Temperature { get; set; }
        public int Top_P { get; set; }
    }
    public class MessageContent
    {
        public string type { get; set; }
        public string text { get; set; }
    }
    public class Message
    {
        public string role { get; set; }
        public List<MessageContent> content { get; set; }
    }
    public class Payload
    {
        public List<Message> messages { get; set; }
        public string project_id { get; set; }
        public string model_id { get; set; }
        public int frequency_penalty { get; set; }
        public int max_tokens { get; set; }
        public int presence_penalty { get; set; }
        public int temperature { get; set; }
        public int top_p { get; set; }
        public object seed { get; set; }
        public List<object> stop { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        private SpeechConfig BOT;
        private SpeechRecognizer speechRecognizer;
        private string? accessToken;
        private string input;
        private string output;

        public MainPage()
        {
            InitializeComponent();
            BOT = SpeechConfig.FromEndpoint(new Uri("https://westus2.api.cognitive.microsoft.com/"));
            speechRecognizer = new SpeechRecognizer(BOT);
        }
        private async void START_Clicked(object sender, EventArgs e)
        {
            try
            {
                await DISABILITASKEYBOARD();
            }
            finally
            {
                speechRecognizer.Dispose();
            }
        }

        private void PAUSE_Clicked(object sender, EventArgs e)
        {
            if(speechRecognizer.RecognizeOnceAsync().Result.Text is not null)
            {
                speechRecognizer.StopContinuousRecognitionAsync();
            }
            else
            {
                speechRecognizer.RecognizeOnceAsync();
            }
        }
        private void RESUME_Clicked(object sender, EventArgs e)
        {
        }

        private void DARURAT_Clicked(object sender, EventArgs e)
        {

        }

        private void completions_Clicked(object sender, EventArgs e)
        {

        }

        private void A_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "A";
        }

        private void B_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "B";
        }

        private void C_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "C";
        }

        private void D_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "D";
        }

        private void E_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "E";
        }

        private void F_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "F";
        }

        private void G_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "G";
        }

        private void H_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "I";
        }

        private void I_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "I";
        }

        private void J_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "J";
        }

        private void K_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "K";
        }

        private void L_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "L";
        }

        private void M_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "M";
        }

        private void N_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "N";
        }

        private void O_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "O";
        }

        private void P_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "P";
        }
        private void Q_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "Q";
        }

        private void R_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "R";
        }

        private void S_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "S";
        }

        private void T_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "T";
        }

        private void U_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "U";
        }

        private void V_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "V";
        }

        private void W_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "W";
        }

        private void X_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "X";
        }

        private void Y_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "Y";
        }

        private void Z_Clicked(object sender, EventArgs e)
        {
            INPUTMESIN.Text += "Z";
        }
        private async Task CopilotDisabilitas()
        {
            if(INPUTMESIN.Text.Length > 5)
            {
                string prompt = INPUTMESIN.Text;
                input += prompt + "Perbaiki kalimat Ini";
                string output = await IBMPROSSESORAGENT();
                await TextToSpeech.Default.SpeakAsync(output);
            }
        }
        private async Task<string?> GetAccessTokenAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://iam.cloud.ibm.com/identity/token");

                request.Content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("grant_type", "urn:ibm:params:oauth:grant-type:apikey"),
                new KeyValuePair<string, string>("apikey", "vjVGUbjhZHU6mYwjnRvwQNo0ZvpRO9N2dQoigvA2OAH3")
            });

                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Ambil access_token dari JSON
                    using (var doc = JsonDocument.Parse(responseContent))
                    {
                        var token = doc.RootElement.GetProperty("access_token").GetString();
                        return token;
                    }
                }
                else
                {
                    throw new Exception($"Gagal ambil token: {response.StatusCode}\n{responseContent}");
                }
            }
        }
        private async Task EKONOMIKEMITRAAN()
        {
        }
        //entar algoritma yang dibuat hari ini bisa untuk buat produk seperti duolingo,education dan otomasi dokumen
        private async Task<string> IBMPROSSESORAGENT()
        {
            if(input is not null && input.Length > 4) {
                string output = "";
                try
                {
                    string url = "https://us-south.ml.cloud.ibm.com/ml/v1/text/chat?version=2023-05-29";
                    var payload = new Payload
                    {
                        messages = new List<Message>
                {
                new Message
                {
                    role = "user",
                    content = new List<MessageContent>
                    {
                        new MessageContent
                        {
                            type = "text",
                            text = input,
                        },
                    }
                }
                },
                        project_id = "e47e2d70-d100-4517-88bb-373082e5b84d",
                        model_id = "ibm/granite-3-3-8b-instruct",
                        frequency_penalty = 0,
                        max_tokens = 2000,
                        presence_penalty = 0,
                        temperature = 0,
                        top_p = 1,
                        seed = null,
                        stop = new List<object>()
                    };
                    string jsonPayload = JsonConvert.SerializeObject(payload, Formatting.Indented);
                    using (HttpClient client = new HttpClient())
                    {
                        accessToken = await GetAccessTokenAsync();
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                        try
                        {
                            HttpResponseMessage response = await client.PostAsync(url, content);
                            string result = await response.Content.ReadAsStringAsync();
                            if (response.IsSuccessStatusCode)
                            {
                                JObject obj = JObject.Parse(result);
                                string assistantMessage = (string)obj["choices"][0]["message"]["content"];
                                output += assistantMessage;
                            }
                        }
                        finally
                        {
                            client.Dispose();
                        }
                    }
                }
                finally
                {
                    //build startup saja dokumen prossesing submit
                    IBMPROSSESORAGENT().Wait(1000);
                }
            }
            return output;
        }
        private async void AKSISATUDARURAT_Clicked(object sender, EventArgs e)
        {
            int DARURATULANG = 3;
            for (int i = 0; i < DARURATULANG; i++)
            {
                switch (i)
                {
                    case 0:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 1:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 2:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    default:
                        await TextToSpeech.Default.SpeakAsync("Okay");
                        break;
                }
            }
        }
        private async void AKSIDUADARURAT_Clicked(object sender, EventArgs e)
        {
            int DARURATULANG = 3;
            for (int i = 0; i < DARURATULANG; i++)
            {
                switch (i)
                {
                    case 0:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 1:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 2:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    default:
                        await TextToSpeech.Default.SpeakAsync("Okay");
                        break;
                }
            }
        }

        private async void AKSITIGADARURAT_Clicked(object sender, EventArgs e)
        {
            int DARURATULANG = 3;
            for (int i = 0; i < DARURATULANG; i++)
            {
                switch (i)
                {
                    case 0:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 1:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 2:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    default:
                        await TextToSpeech.Default.SpeakAsync("Okay");
                        break;
                }
            }
        }

        private async void AKSIEMPATDARURAT_Clicked(object sender, EventArgs e)
        {
            int DARURATULANG = 3;
            for (int i = 0; i < DARURATULANG; i++)
            {
                switch (i)
                {
                    case 0:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 1:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 2:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    default:
                        await TextToSpeech.Default.SpeakAsync("Okay");
                        break;
                }
            }
        }

        private async void AKSILIMADARURAT_Clicked(object sender, EventArgs e)
        {
            int DARURATULANG = 3;
            for (int i = 0; i < DARURATULANG; i++)
            {
                switch (i)
                {
                    case 0:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 1:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 2:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    default:
                        await TextToSpeech.Default.SpeakAsync("Okay");
                        break;
                }
            }
        }

        private async void AKSIENAMDARURAT_Clicked(object sender, EventArgs e)
        {
            int DARURATULANG = 3;
            for (int i = 0; i < DARURATULANG; i++)
            {
                switch (i)
                {
                    case 0:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 1:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 2:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    default:
                        await TextToSpeech.Default.SpeakAsync("Okay");
                        break;
                }
            }
        }

        private async void AKSISATUAKTIFITAS_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 1:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 2:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    default:
                        await TextToSpeech.Default.SpeakAsync("Okay");
                        break;
                }
            }
        }

        private async void AKSIDUAAKTIFITAS_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }
        private async void AKSITIGAAKTIFITAS_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }

        private async void AKSIEMPATAKTIFITAS_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 1:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 2:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    default:
                        await TextToSpeech.Default.SpeakAsync("Okay");
                        break;
                }
            }
        }

        private async void AKSILIMAAKTIFITAS_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 1:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 2:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    default:
                        await TextToSpeech.Default.SpeakAsync("Okay");
                        break;
                }
            }
        }

        private async void AKSIENAMAKTIFITAS_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 2;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        await TextToSpeech.Default.SpeakAsync("Tolong Saya");
                        break;
                    case 1:
                        await TextToSpeech.Default.SpeakAsync("Tolong Saya");
                        break;
                    case 2:
                        await TextToSpeech.Default.SpeakAsync("Tolong Saya");
                        break;
                    default:
                        await TextToSpeech.Default.SpeakAsync("Tolong Saya");
                        break;
                }
            }
        }

        private async void AKSISATUWORKING_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 1:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    case 2:
                        await TextToSpeech.Default.SpeakAsync("");
                        break;
                    default:
                        await TextToSpeech.Default.SpeakAsync("Okay");
                        break;
                }
            }
        }

        private void AKSIDUAWORKING_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AKSITIGAWORKING_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AKSIEMPATWORKING_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AKSILIMAWORKING_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }
        private void AKSIENAMWORKING_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AKSISATUSEKOLAH_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AKSIDUASEKOLAH_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AKSITIGASEKOLAH_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AKSIEMPATSEKOLAH_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }
        //TIDAK ADA KASIH DALAM KODE
        private void AKSILIMASEKOLAH_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AKSIENAMSEKOLAH_Clicked(object sender, EventArgs e)
        {
            int ATURAN = 3;
            for (int i = 0; i < ATURAN; i++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }
        private async Task DISABILITASKEYBOARD()
        {
            try
            {
                speechRecognizer.Recognizing += (s, e) =>
                {
                    if (e.Result.Text is not null)
                    {
                        DISABILITASKEYBOARDSSS.IsVisible = false;
                        speechRecognizer.Recognized += (s, e) =>
                        {
                            string input = e.Result.Text;
                            string finalinput = input.ToUpper();
                            List<string> DATATEKS = finalinput.Split(" ").ToList();
                            for (int x = 0; x < DATATEKS.Count; x++)
                            {
                                if (DATATEKS[x].Length <= 5)
                                {
                                    List<string> DATAHURUF = DATATEKS[x].Split("").ToList();
                                    for (global::System.Int32 y = 0; y < DATAHURUF.Count; y++)
                                    {
                                        if (DATAHURUF[0] is not null && DATAHURUF[0] == DATAHURUF[y])
                                        {
                                            TRANSLATORALATBANTUINDEKSATU.IsVisible = true;
                                            switch (DATAHURUF[0])
                                            {
                                                //arep njaili nyong caranen agar menghapus kode jika error kan tidak aku sudah siap jadi senior tahan bebragai error
                                                //kode is my pelampiasan positif
                                                case string A when DATAHURUF[0] == "A":
                                                    AA.IsVisible = true;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string B when DATAHURUF[0] == "B":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = true;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string C when DATAHURUF[0] == "C":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = true;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string D when DATAHURUF[0] == "D":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = true;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string E when DATAHURUF[0] == "E":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = true;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string F when DATAHURUF[0] == "F":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = true;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                //nih kan satya bisa humanis
                                                case string G when DATAHURUF[0] == "G":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = true;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string H when DATAHURUF[0] == "H":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = true;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string I when DATAHURUF[0] == "I":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = true;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string J when DATAHURUF[0] == "J":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = true;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string K when DATAHURUF[0] == "K":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = true;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string L when DATAHURUF[0] == "L":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = true;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string M when DATAHURUF[0] == "M":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = true;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string N when DATAHURUF[0] == "N":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = true;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string O when DATAHURUF[0] == "O":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = true;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string P when DATAHURUF[0] == "P":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = true;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string Q when DATAHURUF[0] == "Q":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = true;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string R when DATAHURUF[0] == "R":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = true;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string S when DATAHURUF[0] == "S":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = true;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string T when DATAHURUF[0] == "T":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = true;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string U when DATAHURUF[0] == "U":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = true;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string V when DATAHURUF[0] == "V":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = true;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string W when DATAHURUF[0] == "W":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = true;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string X when DATAHURUF[0] == "X":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = true;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string Y when DATAHURUF[0] == "Y":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = true;
                                                    ZZ.IsVisible = false;
                                                    break;
                                                case string Z when DATAHURUF[0] == "Z":
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = true;
                                                    break;
                                                default:
                                                    AA.IsVisible = false;
                                                    BB.IsVisible = false;
                                                    CC.IsVisible = false;
                                                    DD.IsVisible = false;
                                                    EE.IsVisible = false;
                                                    FF.IsVisible = false;
                                                    GG.IsVisible = false;
                                                    HH.IsVisible = false;
                                                    II.IsVisible = false;
                                                    JJ.IsVisible = false;
                                                    KK.IsVisible = false;
                                                    LL.IsVisible = false;
                                                    MM.IsVisible = false;
                                                    NN.IsVisible = false;
                                                    OO.IsVisible = false;
                                                    PP.IsVisible = false;
                                                    QQ.IsVisible = false;
                                                    RR.IsVisible = false;
                                                    SS.IsVisible = false;
                                                    TT.IsVisible = false;
                                                    UU.IsVisible = false;
                                                    VV.IsVisible = false;
                                                    WW.IsVisible = false;
                                                    XX.IsVisible = false;
                                                    YY.IsVisible = false;
                                                    ZZ.IsVisible = false;
                                                    break;
                                            }
                                        }
                                        else if (DATAHURUF[1] is not null && DATAHURUF[1] == DATAHURUF[y] && DATAHURUF[1] != DATAHURUF[0])
                                        {
                                            ALATTRANSLATORINDEKSDUA.IsVisible = true;
                                            switch (DATAHURUF[1])
                                            {
                                                //kode is my pelampiasan positif
                                                case string A when DATAHURUF[1] == "A" && DATAHURUF[1 + 1] != "A":
                                                    TWOAA.IsVisible = true;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string B when DATAHURUF[1] == "B" && DATAHURUF[1 + 1] != "B" && DATAHURUF[1 - 1] != "B":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = true;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string C when DATAHURUF[1] == "C" && DATAHURUF[1 + 1] != "C" && DATAHURUF[1 - 1] != "C":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string D when DATAHURUF[1] == "D" && DATAHURUF[1 + 1] != "D" && DATAHURUF[1 - 1] != "D":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = true;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string E when DATAHURUF[1] == "E" && DATAHURUF[1 + 1] != "E" && DATAHURUF[1 - 1] != "E":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = true;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string F when DATAHURUF[1] == "F" && DATAHURUF[1 + 1] != "F" && DATAHURUF[1 - 1] != "F":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = true;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                //nih kan satya bisa humanis
                                                case string G when DATAHURUF[1] == "G" && DATAHURUF[1 + 1] != "G" && DATAHURUF[1 - 1] != "G":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = true;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string H when DATAHURUF[1] == "H" && DATAHURUF[1 + 1] != "H" && DATAHURUF[1 - 1] != "H":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = true;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string I when DATAHURUF[1] == "I" && DATAHURUF[1 + 1] != "I" && DATAHURUF[1 - 1] != "I":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = true;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string J when DATAHURUF[1] == "J" && DATAHURUF[1 + 1] != "J" && DATAHURUF[1 - 1] != "J":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = true;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string K when DATAHURUF[1] == "K" && DATAHURUF[1 + 1] != "K" && DATAHURUF[1 - 1] != "K":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = true;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string L when DATAHURUF[1] == "L" && DATAHURUF[1 + 1] != "L" && DATAHURUF[1 - 1] != "L":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = true;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string M when DATAHURUF[1] == "M" && DATAHURUF[1 + 1] != "M" && DATAHURUF[1 - 1] != "M":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = true;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string N when DATAHURUF[1] == "N" && DATAHURUF[1 + 1] != "N" && DATAHURUF[1 - 1] != "N":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = true;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string O when DATAHURUF[1] == "O" && DATAHURUF[1 + 1] != "O" && DATAHURUF[1 - 1] != "O":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = true;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string P when DATAHURUF[1] == "P" && DATAHURUF[1 + 1] != "P" && DATAHURUF[1 - 1] != "P":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = true;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string Q when DATAHURUF[1] == "Q" && DATAHURUF[1 + 1] != "Q" && DATAHURUF[1 - 1] != "Q":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = true;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string R when DATAHURUF[1] == "R" && DATAHURUF[1 + 1] != "R" && DATAHURUF[1 - 1] != "R":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = true;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string S when DATAHURUF[1] == "S" && DATAHURUF[1 + 1] != "S" && DATAHURUF[1 - 1] != "S":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = true;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string T when DATAHURUF[1] == "T" && DATAHURUF[1 + 1] != "T" && DATAHURUF[1 - 1] != "T":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = true;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string U when DATAHURUF[1] == "U" && DATAHURUF[1 + 1] != "U" && DATAHURUF[1 - 1] != "U":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = true;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string V when DATAHURUF[1] == "V" && DATAHURUF[1 + 1] != "V" && DATAHURUF[1 - 1] != "V":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = true;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string W when DATAHURUF[1] == "W" && DATAHURUF[1 + 1] != "W" && DATAHURUF[1 - 1] != "W":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = true;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string X when DATAHURUF[1] == "X" && DATAHURUF[1 + 1] != "X" && DATAHURUF[1 - 1] != "X":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = true;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string Y when DATAHURUF[1] == "Y" && DATAHURUF[1 + 1] != "Y" && DATAHURUF[1 - 1] != "Y":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = true;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                                case string Z when DATAHURUF[1] == "Z" && DATAHURUF[1 + 1] != "Z" && DATAHURUF[1 - 1] != "Z":
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = true;
                                                    break;
                                                default:
                                                    TWOAA.IsVisible = false;
                                                    TWOBB.IsVisible = false;
                                                    TWOCC.IsVisible = false;
                                                    TWODD.IsVisible = false;
                                                    TWOEE.IsVisible = false;
                                                    TWOFF.IsVisible = false;
                                                    TWOGG.IsVisible = false;
                                                    TWOHH.IsVisible = false;
                                                    TWOII.IsVisible = false;
                                                    TWOJJ.IsVisible = false;
                                                    TWOKK.IsVisible = false;
                                                    TWOLL.IsVisible = false;
                                                    TWOMM.IsVisible = false;
                                                    TWONN.IsVisible = false;
                                                    TWOOO.IsVisible = false;
                                                    TWOPP.IsVisible = false;
                                                    TWOQQ.IsVisible = false;
                                                    TWORR.IsVisible = false;
                                                    TWOSS.IsVisible = false;
                                                    TWOTT.IsVisible = false;
                                                    TWOUU.IsVisible = false;
                                                    TWOVV.IsVisible = false;
                                                    TWOWW.IsVisible = false;
                                                    TWOXX.IsVisible = false;
                                                    TWOYY.IsVisible = false;
                                                    TWOZZ.IsVisible = false;
                                                    break;
                                            }
                                        }
                                        else if (DATAHURUF[2] == DATAHURUF[y] && DATAHURUF[2] is not null && DATAHURUF[2] != DATAHURUF[1])
                                        {
                                            switch (DATAHURUF[2])
                                            {
                                                //kode is my pelampiasan positif
                                                case string A when DATAHURUF[2] == "A" && DATAHURUF[2 + 1] != "A":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = true;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string B when DATAHURUF[2] == "B" && DATAHURUF[2 + 1] != "B" && DATAHURUF[2 - 1] != "B":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = true;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string C when DATAHURUF[2] == "C" && DATAHURUF[2 + 1] != "C" && DATAHURUF[2 - 1] != "C":
                                                    THREEAA.IsVisible = false ;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = true;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string D when DATAHURUF[2] == "D" && DATAHURUF[2 + 1] != "D" && DATAHURUF[2 - 1] != "D":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = true;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string E when DATAHURUF[2] == "E" && DATAHURUF[2 + 1] != "E" && DATAHURUF[2 - 1] != "E":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = true;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string F when DATAHURUF[2] == "F" && DATAHURUF[2 + 1] != "F" && DATAHURUF[2 - 1] != "F":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = true;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                //nih kan satya bisa humanis
                                                case string G when DATAHURUF[2] == "G" && DATAHURUF[2 + 1] != "G" && DATAHURUF[2 - 1] != "G":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = true;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string H when DATAHURUF[2] == "H" && DATAHURUF[2 + 1] != "H" && DATAHURUF[2 - 1] != "H":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = true;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string I when DATAHURUF[2] == "I" && DATAHURUF[2 + 1] != "I" && DATAHURUF[2 - 1] != "I":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = true;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string J when DATAHURUF[2] == "J" && DATAHURUF[2 + 1] != "J" && DATAHURUF[2 - 1] != "J":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = true;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string K when DATAHURUF[2] == "K" && DATAHURUF[2 + 1] != "K" && DATAHURUF[2 - 1] != "K":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = true;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string L when DATAHURUF[2] == "L" && DATAHURUF[2 + 1] != "L" && DATAHURUF[2 - 1] != "L":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = true;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                //jadi untuk klasifikasi 5 kalimat
                                                case string M when DATAHURUF[2] == "M" && DATAHURUF[2 + 1] != "M" && DATAHURUF[2 - 1] != "M":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = true;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string N when DATAHURUF[2] == "N" && DATAHURUF[2 + 1] != "N" && DATAHURUF[2 - 1] != "N":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = true;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string O when DATAHURUF[2] == "O" && DATAHURUF[2 + 1] != "O" && DATAHURUF[2 - 1] != "O":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = true;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string P when DATAHURUF[2] == "P" && DATAHURUF[2 + 1] != "P" && DATAHURUF[2 - 1] != "P":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = true;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string Q when DATAHURUF[2] == "Q" && DATAHURUF[2 + 1] != "Q" && DATAHURUF[2 - 1] != "Q":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = true;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string R when DATAHURUF[2] == "R" && DATAHURUF[2 + 1] != "R" && DATAHURUF[2 - 1] != "R":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = true;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string S when DATAHURUF[2] == "S" && DATAHURUF[2 + 1] != "S" && DATAHURUF[2 - 1] != "S":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = true;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string T when DATAHURUF[2] == "T" && DATAHURUF[2 + 1] != "T" && DATAHURUF[2 - 1] != "T":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = true;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string U when DATAHURUF[2] == "U" && DATAHURUF[2 + 1] != "U" && DATAHURUF[2 - 1] != "U":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = true;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string V when DATAHURUF[2] == "V" && DATAHURUF[2 + 1] != "V" && DATAHURUF[2 - 1] != "V":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = true;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string W when DATAHURUF[2] == "W" && DATAHURUF[2 + 1] != "W" && DATAHURUF[2 - 1] != "W":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = true;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string X when DATAHURUF[2] == "X" && DATAHURUF[2 + 1] != "X" && DATAHURUF[2 - 1] != "X":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = true;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string Y when DATAHURUF[2] == "Y" && DATAHURUF[2 + 1] != "Y" && DATAHURUF[2 - 1] != "Y":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = true;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                                case string Z when DATAHURUF[2] == "Z" && DATAHURUF[2 + 1] != "Z" && DATAHURUF[2 - 1] != "Z":
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = true;
                                                    break;
                                                default:
                                                    THREEAA.IsVisible = false;
                                                    THREEBB.IsVisible = false;
                                                    THREECC.IsVisible = false;
                                                    THREEDD.IsVisible = false;
                                                    THREEEE.IsVisible = false;
                                                    THREEFF.IsVisible = false;
                                                    THREEGG.IsVisible = false;
                                                    THREEHH.IsVisible = false;
                                                    THREEII.IsVisible = false;
                                                    THREEJJ.IsVisible = false;
                                                    THREEKK.IsVisible = false;
                                                    THREELL.IsVisible = false;
                                                    THREEMM.IsVisible = false;
                                                    THREENN.IsVisible = false;
                                                    THREEOO.IsVisible = false;
                                                    THREEPP.IsVisible = false;
                                                    THREEQQ.IsVisible = false;
                                                    THREERR.IsVisible = false;
                                                    THREESS.IsVisible = false;
                                                    THREETT.IsVisible = false;
                                                    THREEUU.IsVisible = false;
                                                    THREEVV.IsVisible = false;
                                                    THREEWW.IsVisible = false;
                                                    THREEXX.IsVisible = false;
                                                    THREEYY.IsVisible = false;
                                                    THREEZZ.IsVisible = false;
                                                    break;
                                            }
                                        }
                                        //entar algoritma ini bisa walaupun untuk sosial bisa untuk bisnis juga tergantung mau tipe data double atau integer
                                        else if (DATATEKS[3] is not null && DATAHURUF[3] == DATAHURUF[y] && DATAHURUF[3] != DATAHURUF[2])
                                        {
                                            ALATTRANSLATORINDEKSEMPAT.IsVisible = true;
                                            switch (DATAHURUF[3])
                                            {
                                                //kode is my pelampiasan positif
                                                case string A when DATAHURUF[3] == "A" && DATAHURUF[3 + 1] != "A":
                                                    FOURAA.IsVisible = true;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string B when DATAHURUF[3] == "B" && DATAHURUF[3 + 1] != "B" && DATAHURUF[3 - 1] != "B":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = true;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string C when DATAHURUF[3] == "C" && DATAHURUF[3 + 1] != "C" && DATAHURUF[3 - 1] != "C":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = true;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string D when DATAHURUF[3] == "D" && DATAHURUF[3 + 1] != "D" && DATAHURUF[3 - 1] != "D":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = true;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string E when DATAHURUF[3] == "E" && DATAHURUF[3 + 1] != "E" && DATAHURUF[3 - 1] != "E":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = true;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string F when DATAHURUF[3] == "F" && DATAHURUF[3 + 1] != "F" && DATAHURUF[3 - 1] != "F":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = true;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                //nih kan satya bisa humanis
                                                case string G when DATAHURUF[3] == "G" && DATAHURUF[3 + 1] != "G" && DATAHURUF[3 - 1] != "G":
                                                    FOURAA.IsVisible = true;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = true;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string H when DATAHURUF[3] == "H" && DATAHURUF[3 + 1] != "H" && DATAHURUF[3 - 1] != "H":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = true;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string I when DATAHURUF[3] == "I" && DATAHURUF[3 + 1] != "I" && DATAHURUF[3 - 1] != "I":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = true;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string J when DATAHURUF[3] == "J" && DATAHURUF[3 + 1] != "J" && DATAHURUF[3 - 1] != "J":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = true;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string K when DATAHURUF[3] == "K" && DATAHURUF[3 + 1] != "K" && DATAHURUF[3 - 1] != "K":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = true;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string L when DATAHURUF[3] == "L" && DATAHURUF[3 + 1] != "L" && DATAHURUF[3 - 1] != "L":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = true;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string M when DATAHURUF[3] == "M" && DATAHURUF[3 + 1] != "M" && DATAHURUF[3 - 1] != "M":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = true;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string N when DATAHURUF[3] == "N" && DATAHURUF[3 + 1] != "N" && DATAHURUF[3 - 1] != "N":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = true;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string O when DATAHURUF[3] == "O" && DATAHURUF[3 + 1] != "O" && DATAHURUF[3 - 1] != "O":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = true;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string P when DATAHURUF[3] == "P" && DATAHURUF[3 + 1] != "P" && DATAHURUF[3 - 1] != "P":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = true;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string Q when DATAHURUF[3] == "Q" && DATAHURUF[3 + 1] != "Q" && DATAHURUF[3 - 1] != "Q":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = true;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string R when DATAHURUF[3] == "R" && DATAHURUF[3 + 1] != "R" && DATAHURUF[3 - 1] != "R":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = true;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string S when DATAHURUF[3] == "S" && DATAHURUF[3 + 1] != "S" && DATAHURUF[3 - 1] != "S":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = true;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string T when DATAHURUF[3] == "T" && DATAHURUF[3 + 1] != "T" && DATAHURUF[3 - 1] != "T":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = true;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string U when DATAHURUF[3] == "U" && DATAHURUF[3 + 1] != "U" && DATAHURUF[3 - 1] != "U":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = true;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string V when DATAHURUF[3] == "V" && DATAHURUF[3 + 1] != "V" && DATAHURUF[3 - 1] != "V":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = true;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string W when DATAHURUF[3] == "W" && DATAHURUF[3 + 1] != "W" && DATAHURUF[3 - 1] != "W":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = true;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string X when DATAHURUF[3] == "X" && DATAHURUF[3 + 1] != "X" && DATAHURUF[3 - 1] != "X":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = true;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string Y when DATAHURUF[3] == "Y" && DATAHURUF[3 + 1] != "Y" && DATAHURUF[3 - 1] != "Y":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = true;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                                case string Z when DATAHURUF[3] == "Z" && DATAHURUF[3 + 1] != "Z" && DATAHURUF[3 - 1] != "Z":
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = true;
                                                    break;
                                                default:
                                                    FOURAA.IsVisible = false;
                                                    FOURBB.IsVisible = false;
                                                    FOURCC.IsVisible = false;
                                                    FOURDD.IsVisible = false;
                                                    FOUREE.IsVisible = false;
                                                    FOURFF.IsVisible = false;
                                                    FOURGG.IsVisible = false;
                                                    FOURHH.IsVisible = false;
                                                    FOURII.IsVisible = false;
                                                    FOURJJ.IsVisible = false;
                                                    FOURKK.IsVisible = false;
                                                    FOURLL.IsVisible = false;
                                                    FOURMM.IsVisible = false;
                                                    FOURNN.IsVisible = false;
                                                    FOUROO.IsVisible = false;
                                                    FOURPP.IsVisible = false;
                                                    FOURQQ.IsVisible = false;
                                                    FOURRR.IsVisible = false;
                                                    FOURSS.IsVisible = false;
                                                    FOURTT.IsVisible = false;
                                                    FOURUU.IsVisible = false;
                                                    FOURVV.IsVisible = false;
                                                    FOURWW.IsVisible = false;
                                                    FOURXX.IsVisible = false;
                                                    FOURYY.IsVisible = false;
                                                    FOURZZ.IsVisible = false;
                                                    break;
                                            }
                                        }
                                        else if (DATAHURUF[4] == DATAHURUF[y] && DATAHURUF[4] is not null && DATAHURUF[4] != DATAHURUF[3])
                                        {
                                            TRANSLATORALATBANTUINDEKSLIMA.IsVisible = true;
                                            switch (DATAHURUF[4])
                                            {
                                                //kode is my pelampiasan positif
                                                case string A when DATAHURUF[4] == "A" && DATAHURUF[4 + 1] != "A":
                                                    FIVEAA.IsVisible = true;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string B when DATAHURUF[4] == "B" && DATAHURUF[4 + 1] != "B" && DATAHURUF[4 - 1] != "B":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = true;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string C when DATAHURUF[4] == "C" && DATAHURUF[4 + 1] != "C" && DATAHURUF[4 - 1] != "C":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = true;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string D when DATAHURUF[4] == "D" && DATAHURUF[4 + 1] != "D" && DATAHURUF[4 - 1] != "D":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = true;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string E when DATAHURUF[4] == "E" && DATAHURUF[4 + 1] != "E" && DATAHURUF[4 - 1] != "E":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = true;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string F when DATAHURUF[4] == "F" && DATAHURUF[y + y] != "F" && DATAHURUF[4 - 1] != "F":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = true;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                    //tidak ada nafsu dalam kode
                                                //nih kan satya bisa humanis
                                                case string G when DATAHURUF[4] == "G" && DATAHURUF[y + y] != "G" && DATAHURUF[4 - 1] != "G":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = true;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string H when DATAHURUF[4] == "H" && DATAHURUF[y + y] != "H" && DATAHURUF[4 - 1] != "H":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = true;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string I when DATAHURUF[4] == "I" && DATAHURUF[y + y] != "I" && DATAHURUF[4 - 1] != "I":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = true;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string J when DATAHURUF[4] == "J" && DATAHURUF[y + y] != "J" && DATAHURUF[4 - 1] != "J":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = true;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string K when DATAHURUF[4] == "K" && DATAHURUF[y + y] != "K" && DATAHURUF[4 - 1] != "K":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = true;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string L when DATAHURUF[4] == "L" && DATAHURUF[y + y] != "L" && DATAHURUF[4 - 1] != "L":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = true;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string M when DATAHURUF[4] == "M" && DATAHURUF[y + y] != "M" && DATAHURUF[4 - 1] != "M":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = true;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string N when DATAHURUF[4] == "N" && DATAHURUF[y + y] != "N" && DATAHURUF[4 - 1] != "N":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = true;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string O when DATAHURUF[4] == "O" && DATAHURUF[y + y] != "O" && DATAHURUF[4 - 1] != "O":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = true;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string P when DATAHURUF[4] == "P" && DATAHURUF[y + y] != "P" && DATAHURUF[4 - 1] != "P":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = true;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string Q when DATAHURUF[4] == "Q" && DATAHURUF[y + y] != "Q" && DATAHURUF[4 - 1] != "Q":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = true;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string R when DATAHURUF[4] == "R" && DATAHURUF[y + y] != "R" && DATAHURUF[4 - 1] != "R":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = true;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string S when DATAHURUF[4] == "S" && DATAHURUF[y + y] != "S" && DATAHURUF[4 - 1] != "S":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = true;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string T when DATAHURUF[4] == "T" && DATAHURUF[y + y] != "T" && DATAHURUF[4 - 1] != "T":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = true;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string U when DATAHURUF[4] == "U" && DATAHURUF[y + y] != "U" && DATAHURUF[4 - 1] != "U":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = true;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string V when DATAHURUF[4] == "V" && DATAHURUF[y + y] != "V" && DATAHURUF[4 - 1] != "V":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = true;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string W when DATAHURUF[4] == "W" && DATAHURUF[y + y] != "W" && DATAHURUF[4 - 1] != "W":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = true;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string X when DATAHURUF[4] == "X" && DATAHURUF[y + y] != "X" && DATAHURUF[4 - 1] != "X":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = true;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string Y when DATAHURUF[4] == "Y" && DATAHURUF[y + y] != "Y" && DATAHURUF[4 - 1] != "Y":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = true;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                                case string Z when DATAHURUF[4] == "Z" && DATAHURUF[y + y] != "Z" && DATAHURUF[4 - 1] != "Z":
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = true;
                                                    break;
                                                default:
                                                    FIVEAA.IsVisible = false;
                                                    FIVEBB.IsVisible = false;
                                                    FIVECC.IsVisible = false;
                                                    FIVEDD.IsVisible = false;
                                                    FIVEEE.IsVisible = false;
                                                    FIVEFF.IsVisible = false;
                                                    FIVEGG.IsVisible = false;
                                                    FIVEHH.IsVisible = false;
                                                    FIVEII.IsVisible = false;
                                                    FIVEJJ.IsVisible = false;
                                                    FIVEKK.IsVisible = false;
                                                    FIVELL.IsVisible = false;
                                                    FIVEMM.IsVisible = false;
                                                    FIVENN.IsVisible = false;
                                                    FIVEOO.IsVisible = false;
                                                    FIVEPP.IsVisible = false;
                                                    FIVEQQ.IsVisible = false;
                                                    FIVERR.IsVisible = false;
                                                    FIVESS.IsVisible = false;
                                                    FIVETT.IsVisible = false;
                                                    FIVEUU.IsVisible = false;
                                                    FIVEVV.IsVisible = false;
                                                    FIVEWW.IsVisible = false;
                                                    FIVEXX.IsVisible = false;
                                                    FIVEYY.IsVisible = false;
                                                    FIVEZZ.IsVisible = false;
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            DISABILITASKEYBOARDSSS.IsVisible = true;
                        };
                    }
                };
            }
            finally
            {
                TRANSLATORALATBANTUINDEKSATU.IsVisible = false;
                TRANSLATORALATBANTUINDEKSDUA.IsVisible = false;
                TRANSLATORALATBANTUINDEKSTIGA.IsVisible = false;
                TRANSLATORALATBANTUINDEKSEMPAT.IsVisible = false;
                TRANSLATORALATBANTUINDEKSLIMA.IsVisible = false;
            };
        }

        private void COPILOT_Clicked(object sender, EventArgs e)
        {

        }
    }
}
