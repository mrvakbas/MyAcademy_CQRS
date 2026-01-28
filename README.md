## 🥖 Bagery - Pastane & E-Ticaret Yönetim Sistemi
Bagery, modern bir pastane işletmesinin hem son kullanıcıya hitap eden vitrin arayüzünü hem de tüm operasyonel süreçlerin yönetildiği kapsamlı bir admin panelini içeren, kurumsal tasarım desenleri ile geliştirilmiş bir web uygulamasıdır.

## 🛠 Teknik Mimari ve Tasarım Desenleri
Proje, sürdürülebilirlik ve yüksek performans hedeflenerek aşağıdaki mimari yaklaşımlar üzerine inşa edilmiştir:

## ⚡ CQRS (Command Query Responsibility Segregation)
Uygulama içerisinde okuma (Query) ve yazma (Command) işlemleri tamamen birbirinden ayrılmıştır.

Queries: Kampanya listeleme, ürün detayları ve dashboard istatistikleri gibi veriler optimize edilmiş Query objeleri ile getirilir.

Commands: Yeni kampanya ekleme, ürün silme veya sipariş güncelleme gibi "state" değiştiren işlemler Command yapıları üzerinden yürütülür.

## 🔄 MediatR Pattern
Sistemdeki karmaşıklığı azaltmak için MediatR kütüphanesi kullanılmıştır. Controller'lar doğrudan servislerle konuşmak yerine taleplerini bir Mediator aracılığıyla ilgili Handler sınıflarına iletir. Bu sayede sınıflar arası bağımlılık (Coupling) minimuma indirilmiştir.

## 🔗 Chain of Responsibility (Sorumluluk Zinciri)
Admin panelindeki Sistem Aktivite Akışı (Loglama) ve bazı doğrulama süreçlerinde kullanılmıştır. Bir talep (request) geldiğinde, logların hangi modülden (Promotion, Category, Order vb.) geçtiği ve nasıl işleneceği bu zincir yapısıyla belirlenir.

## 🏗 Unit of Work & Repository Pattern
Veritabanı işlemleri Repository deseni ile soyutlanmış; tüm işlemlerin tek bir transaction üzerinden güvenli bir şekilde tamamlanması için Unit of Work yapısı entegre edilmiştir. Bu sayede veri tutarlılığı maksimum düzeyde sağlanır.

## 🕵️ Observer Pattern
Özellikle Dashboard İstatistikleri ve Loglama süreçlerinde kullanılmıştır. Örneğin:

Yeni bir sipariş oluşturulduğunda (Order), sistem otomatik olarak Dashboard üzerindeki sayaçları ve "Sistem Aktivite Akışı" tablosunu tetikleyerek günceller.

## 🎨 Tasarım ve Kullanıcı Deneyimi (UI/UX)
Projenin Admin Paneli tasarımı, Google Gemini yapay zeka modeli ile iş birliği içerisinde, modern dashboard trendlerine uygun olarak geliştirilmiştir.

## 🚀 Öne Çıkan Özellikler
Gelişmiş Dashboard: Kampanya, Ürün, Sipariş ve Log sayılarını anlık gösteren soft tasarımlı kartlar.

Dinamik Timeline: Sistemde yapılan her işlemin (ekleme, silme, güncelleme) modül bazlı renk kodlarıyla (Promotion, Category, Contact) takip edilebildiği log sistemi.

Modern UI/UX: Bootstrap 5 tabanlı, kullanıcı dostu ve responsive tasarım.

Kampanya Yönetimi: CQRS altyapısı ile yönetilen, görsel destekli promosyon sistemi.

## 💻 Teknolojiler
Backend: .NET 9 / .NET Core

Database: Entity Framework Core / MS SQL Server

Design Patterns: CQRS, MediatR, Unit of Work, Repository, Observer, Chain of Responsibility

Frontend: HTML5, CSS3, JavaScript (AJAX & Filter Logic), Bootstrap 5

## 📸 Proje Görselleri
<img width="1600" height="731" alt="1" src="https://github.com/user-attachments/assets/04999ac6-7c23-4a82-ad0b-e3ca2a471cb0" />
<img width="1600" height="731" alt="2" src="https://github.com/user-attachments/assets/d97504d7-8631-407e-8771-b9da328d9042" />
<img width="1600" height="731" alt="3" src="https://github.com/user-attachments/assets/8f1707ce-0ac3-427f-b9b7-2fd862db6c7c" />
<img width="1600" height="1097" alt="Admin1" src="https://github.com/user-attachments/assets/9973ddd1-322d-4b4f-8cbf-1212bb743596" />
<img width="1600" height="961" alt="Admin2Log1" src="https://github.com/user-attachments/assets/70ff2bec-088f-4fe1-8b75-84633ff4413c" />
<img width="1600" height="1116" alt="Admin4Order1" src="https://github.com/user-attachments/assets/1673a881-408f-416f-9b7b-6201cd9475a3" />
<img width="1600" height="731" alt="admin5Kampanya1" src="https://github.com/user-attachments/assets/3b06a91c-1f8e-49be-b227-441cbd0427ab" />
<img width="1600" height="731" alt="Admin5Sipariş1" src="https://github.com/user-attachments/assets/e3834435-2ea6-40c9-81a3-cc5ac9825fc5" />
<img width="1600" height="10378" alt="Index1" src="https://github.com/user-attachments/assets/72a9138b-c92a-48a1-a540-975040f13fa6" />





