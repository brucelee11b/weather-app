namespace Worker
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Seq { get; set; }
    }

    public class Model
    {
        public static List<Province> Provinces =
        [
            new Province{ Id = 1, Name = "HaNoi", Lat = "21.0245", Lon = "105.8412", Seq = "10" },
            //new Province{ Id = 2, Name = "Hagiang", Lat = "22.8274", Lon = "104.9866", Seq = "10" },
            //new Province{ Id = 3, Name = "CaoBang", Lat = "22.6667", Lon = "106.2588", Seq = "10" },
            //new Province{ Id = 4, Name = "LaoCai", Lat = "22.4997", Lon = "103.9657", Seq = "10" },
            //new Province{ Id = 5, Name = "SonLa", Lat = "21.3283", Lon = "103.9005", Seq = "10" },
            //new Province{ Id = 6, Name = "LaiChau", Lat = "22.3997", Lon = "103.4517", Seq = "10" },
            //new Province{ Id = 7, Name = "BacKan", Lat = "22.1495", Lon = "105.8372", Seq = "10" },
            //new Province{ Id = 8, Name = "LangSon", Lat = "21.8505", Lon = "106.7662", Seq = "10" },
            //new Province{ Id = 9, Name = "TuyenQuang", Lat = "21.8233", Lon = "105.2181", Seq = "10" },
            //new Province{ Id = 10, Name = "YenBai", Lat = "21.7026", Lon = "104.8714", Seq = "10" },
            //new Province{ Id = 11, Name = "ThaiNguyen", Lat = "21.5928", Lon = "105.8442", Seq = "10" },
            //new Province{ Id = 12, Name = "DienBien", Lat = "21.3833", Lon = "103.0167", Seq = "10" },
            //new Province{ Id = 13, Name = "PhuTho", Lat = "11.5486", Lon = "109.0281", Seq = "10" },
            //new Province{ Id = 14, Name = "VinhPhuc", Lat = "18.4169", Lon = "105.6954", Seq = "10" },
            //new Province{ Id = 15, Name = "BacGiang", Lat = "21.2779", Lon = "106.1939", Seq = "10" },
            //new Province{ Id = 16, Name = "BacNinh", Lat = "21.1833", Lon = "106.05", Seq = "10" },
            //new Province{ Id = 17, Name = "QuangNinh", Lat = "20.9528", Lon = "107.08", Seq = "10" },
            //new Province{ Id = 18, Name = "HaiDuong", Lat = "20.9333", Lon = "106.3167", Seq = "10" },
            //new Province{ Id = 19, Name = "HaiPhong", Lat = "20.8561", Lon = "106.6822", Seq = "10" },
            //new Province{ Id = 20, Name = "HoaBinh", Lat = "20.813", Lon = "105.3453", Seq = "10" },
            //new Province{ Id = 21, Name = "HungYen", Lat = "20.6491", Lon = "106.051", Seq = "10" },
            //new Province{ Id = 22, Name = "HaNam", Lat = "16.3358", Lon = "107.7706", Seq = "10" },
            //new Province{ Id = 23, Name = "ThaiBinh", Lat = "20.4493", Lon = "106.3425", Seq = "10" },
            //new Province{ Id = 24, Name = "NamDinh", Lat = "20.423", Lon = "106.1684", Seq = "10" },
            //new Province{ Id = 25, Name = "NinhBinh", Lat = "20.2545", Lon = "105.9765", Seq = "10" },
            //new Province{ Id = 26, Name = "ThanhHoa", Lat = "19.8", Lon = "105.7667", Seq = "10" },
            //new Province{ Id = 27, Name = "NgheAn", Lat = "18.6667", Lon = "105.6667", Seq = "10" },
            //new Province{ Id = 28, Name = "HaTinh", Lat = "18.3453", Lon = "105.9019", Seq = "10" },
            //new Province{ Id = 29, Name = "QuangBinh", Lat = "17.4833", Lon = "106.6", Seq = "10" },
            //new Province{ Id = 30, Name = "QuangTri", Lat = "16.75", Lon = "107.2", Seq = "10" },
            //new Province{ Id = 31, Name = "Hue", Lat = "16.4667", Lon = "107.6", Seq = "10" },
            //new Province{ Id = 32, Name = "Danang", Lat = "16.0678", Lon = "108.2208", Seq = "10" },
            //new Province{ Id = 33, Name = "QuangNam", Lat = "15.5757", Lon = "108.4743", Seq = "10" },
            //new Province{ Id = 34, Name = "QuangNgai", Lat = "15.1167", Lon = "108.8", Seq = "10" },
            //new Province{ Id = 35, Name = "KonTum", Lat = "14.35", Lon = "108", Seq = "10" },
            //new Province{ Id = 36, Name = "GiaLai", Lat = "13.75", Lon = "108.25", Seq = "10" },
            //new Province{ Id = 37, Name = "BinhDinh", Lat = "13.886", Lon = "109.1117", Seq = "10" },
            //new Province{ Id = 38, Name = "PhuYen", Lat = "13.0833", Lon = "109.3", Seq = "10" },
            //new Province{ Id = 39, Name = "DakLak", Lat = "12.6667", Lon = "108.05", Seq = "10" },
            //new Province{ Id = 40, Name = "KhanhHoa", Lat = "10.6765", Lon = "105.1903", Seq = "10" },
            //new Province{ Id = 41, Name = "DakNong", Lat = "12.0085", Lon = "107.6901", Seq = "10" },
            //new Province{ Id = 42, Name = "LamDong", Lat = "11.9402", Lon = "108.4376", Seq = "10" },
            //new Province{ Id = 43, Name = "NinhThuan", Lat = "11.5653", Lon = "108.9886", Seq = "10" },
            //new Province{ Id = 44, Name = "BinhPhuoc", Lat = "11.5333", Lon = "106.9167", Seq = "10" },
            //new Province{ Id = 45, Name = "TayNinh", Lat = "11.3135", Lon = "106.096", Seq = "10" },
            //new Province{ Id = 46, Name = "BinhDuong", Lat = "14.2972", Lon = "109.0797", Seq = "10" },
            //new Province{ Id = 47, Name = "DongNai", Lat = "10.9569", Lon = "106.8536", Seq = "10" },
            //new Province{ Id = 48, Name = "BinhThuan", Lat = "10.9333", Lon = "108.1", Seq = "10" },
            //new Province{ Id = 49, Name = "HoChiMinh", Lat = "10.75", Lon = "106.6667", Seq = "10" },
            //new Province{ Id = 50, Name = "LongAn", Lat = "10.6667", Lon = "106.1667", Seq = "10" },
            //new Province{ Id = 51, Name = "BaRiaVungTau", Lat = "10.4963", Lon = "107.1688", Seq = "10" },
            //new Province{ Id = 52, Name = "DongThap", Lat = "10.462", Lon = "105.6358", Seq = "10" },
            //new Province{ Id = 53, Name = "AnGiang", Lat = "10.5", Lon = "105.1667", Seq = "10" },
            //new Province{ Id = 54, Name = "TienGiang", Lat = "10.35", Lon = "106.35", Seq = "10" },
            //new Province{ Id = 55, Name = "VinhLong", Lat = "10.2544", Lon = "105.967", Seq = "10" },
            //new Province{ Id = 56, Name = "BenTre", Lat = "10.2448", Lon = "1106.3735", Seq = "10" },
            //new Province{ Id = 57, Name = "CanTho", Lat = "10.0333", Lon = "105.7833", Seq = "10" },
            //new Province{ Id = 58, Name = "KienGiang", Lat = "10.019", Lon = "105.0822", Seq = "10" },
            //new Province{ Id = 59, Name = "TraVinh", Lat = "9.9356", Lon = "106.3398", Seq = "10" },
            //new Province{ Id = 60, Name = "HauGiang", Lat = "9.7579", Lon = "105.6410", Seq = "10" },
            //new Province{ Id = 61, Name = "SocTrang", Lat = "9.6081", Lon = "105.9715", Seq = "10" },
            //new Province{ Id = 62, Name = "BacLieu", Lat = "9.2825", Lon = "105.7261", Seq = "10" },
            new Province{ Id = 63, Name = "CaMau", Lat = "9.1792", Lon = "105.1458", Seq = "10" }
        ];
    }
}
