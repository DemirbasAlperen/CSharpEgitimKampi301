# :boom: C# Eğitim Kampı (YouTube)

Merhabalar. Bu repomda Murat Yücedağ'ın YouTube kanalında vermiş olduğu C# Kampı eğitimi boyunca yapmış olduğu 301 seviye dersler ve projeler bulunmaktadır. Aşağıda her ders içerisinde yapılan projelerin teknik detayları bulunmaktadır. Yeni dersler ve projeler de yapıldıkça eklenecektir. :blush: 


# :sunny: Proje 11 (301) OOP Modülü: C# ile N Katmanlı Mimari Entity Layer
Bu projede; 301 seviye derslere giriş yapıldı. Boş bir solution açarak projemizi 4 katmandan oluşturduk. EntityLayer katmanı; projeye ait entityler tanımlanacak, DataAccessLayer; proje ile ilgili veritabanı işlemleri yazılacak, BusinessLayer; logic sorgulamaları yapılacak, Presentation / UI Layer (Kullanıcı ara yüzü); lk üç katmanda yapılan işlemler kullanıcıya gösterilecek. Öncelike EntityLayer katmanına Concrete klasörü açıp içerisine sınıflarımızı tanımladık. Bu sınıflar içerisinde property ler olacak, bu propertyler de sql de ilgili tablonun sütunlarına dönüşüyor olacak. Sonrasında Erişim Belirleyiciler hakkında bilgiler verildi. Field-Veriable-Property bunları ve bunlar arasındaki fark anlatıldı.   

# :sunny: Proje 12 (301) OOP Modülü: Data Access Katmanı ve Context Sınıfı
Bu projede; Bir önceki derste eklediğimiz sınıflar arasında ilişki kurduk. Sonra Manage NuGet Packages den Entity Framework paketini yükledik. Sonrasında DataAccessLayer katmanı içerisine Context klasörü açtık ve bu klasörde veri tabanına yansıyacak olan tabloları tuttuk. Katmanlar birbirleri arasında referans alarak çalışacak o yüzden Entity Layer katmanı Data Access Layer katmanına, Data Access Layer katmanı Business Layer katmanına ve Business Layer katmanı da Presentation Layer katmanına referans olarak verdik. Sonra Presentation katmanında App.config dosyasını açtım ve en alt kısma sql bağlantı adresini yazdım.

# :sunny: Proje 13 (301) OOP Modülü: Migration İşlemleri ve Abstract Interfaceler
Bu projede; Migration işlemleri yapıldı. Bu işlem için Öncelikle başlangıç projesi olarak PresentationLayer seçili olmalı, Package Manager Console açılır, burada Default project kısmı var buradan DataAccessLayer seçilir ve migration komutlarını yazdık. DataAccessLayer katmanına Abstract klasörü açtık ve içine Interfaceler lerimizi tanımladık. Sonrasında miras alma şlemlerini yapıp CRUD işlemleri için hazır hale getirdik.

# :sunny: Proje 14 (301) Orm Yapısı: Entity Framework DbFirst ve Model Oluşturma
Bu projede; Katmanlı mimari projesine ara verip Entity Framework konusuna geçtik. Entity Framework bir Orm yapısıdır. Bunun için CSharpEgitimKampi301.EFProject isimli yeni bir proje açtık ve Sql de gerekli tablolar oluşturduk. Sonrasında projeye dönüp yeni bir item açarak ADO.Net Entity Data Model yapısını seçiyoruz. Böylece DbFirst yaklaşımıyla hazır olan bir veritabanını model olarak Visual Studio ya entegre etmiş olduk. 

# :sunny: Proje 15 (301) Entity Framework Metotları ile Proje Uygulaması
Bu projede; Entity Framework konusuna devam ettik. Form yapısı kullanarak Form1 isimli bir proje yaptık yaptık. Form yapısının araçlarını kullanarak form tasarımı üzerinde değişiklik yapmayı öğrendim. Sql'deki Rehber tablosuna göre işlemler yapıldı. Form içerisine Listele, Ekle, Sil, Güncelle, Id'ye Göre Getir butonları ekledik ve bu butonlara arka planda kod yazarak Sql ile ilişki kurduk.

# :sunny: Proje 16 (301) Entity Framework: Tur Projesi Location İşlemleri
Bu projede; Entity Framework konusuna devam ettik. CSharpEgitimKampi301.EFProject projesi içine FrmLocation isimli yeni bir form açarak form tasarımını düzenledik. Bu formu çalıştırabilmem için proje dosyası içinde bulunan Program.cs dosyasını açıyorum ve Application.Run(new Form1()); yazan kısımdan Form1 kısmını silip kendi forms dosyamın(FrmLocation) adını yazıyorum. Bu sefer Sql de yazdığımız Location talosu üzerinden verileri çektik. Silme ve Güncelleme işlemleri için Id kullandık.

# :sunny: Proje 17 (301) Entity Framework Metotları ve Linq Sorgular
Bu projede; Entity Framework konusuna devam ettik. CSharpEgitimKampi301.EFProject projemiz içinde FrmStatistic isimli yeni bir form dosyası açıyoruz. Form tasarımnı yaparken internet üzerinden bir renk paleti kullandık. Form içerisine 12 tane panel ekledik. Kod içerisinde her bir panel işin yapılan işlemler açıklandı. Bu arada kodu çalıştırdığımızda virgüllü sayıların virgülden sonra iki basamağının gelmesi için ToString() metodu içine "F2" yazdım ve sorun çözüldü. 

/assets/images/FrmStatistic.png
