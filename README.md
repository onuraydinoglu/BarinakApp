# Hayvan Barınağı Yönetim Sistemi (Barınak-App)

## Proje Özeti
Bu proje, hayvan barınaklarının operasyonlarını, özellikle hayvan kaydı ve sahiplendirme süreçlerini dijital ortamda yönetmek için tasarlanmış bir web uygulamasıdır. Uygulama, yönetici ve normal kullanıcı rolleri arasında destek sunar ve hayvan yönetimi ile kullanıcı etkileşimleri için kapsamlı özellikler içerir.

## Projenin Amacı
Uygulamanın amacı, bir hayvan barınağındaki yönetim süreçlerini dijitalleştirerek şu işlevleri sunmaktır:
- Hayvan kaydı ve yönetimi
- Kullanıcı hesap yönetimi
- Hayvanlar hakkında yorum yapabilme
- Hayvanları türlerine göre filtreleme
- Yönetici ve normal kullanıcı rolleri için yetkilendirme

## Kullanılan Teknolojiler

### Backend Framework:
- **ASP.NET Core MVC**
- **Entity Framework Core** (ORM)

### Mimari ve Tasarım Desenleri:
- **Repository Pattern**
- **Dependency Injection**
- **MVC (Model-View-Controller)** mimarisi

### Güvenlik:
- **Cookie tabanlı kimlik doğrulama**
- **Rol tabanlı yetkilendirme**
- **Claims-based authentication**

## Proje Yapısı

### Controllers:
- **AnimalsController**: Hayvanlarla ilgili işlemleri yönetir
- **UsersController**: Kullanıcı işlemlerini (kayıt, giriş, profil yönetimi) yönetir

### Modeller:
- **View Modelleri**:
  - `AnimalViewModel`: Hayvan listelerini görüntüleme
  - `AnimalCreateViewModel`: Hayvan oluşturma/düzenleme
  - `LoginViewModel`: Kullanıcı giriş işlemleri
  - `RegisterViewModel`: Kullanıcı kayıt işlemleri
- **Entity Modelleri**:
  - `Animal`: Hayvan bilgilerini temsil eder
  - `User`: Kullanıcı bilgilerini temsil eder
  - `Breed`: Hayvan türlerini temsil eder
  - `Comment`: Hayvanlar hakkında yapılan yorumları temsil eder

### Repository Pattern:
- **Interface'ler**:
  - `IAnimalRepository`, `IUserRepository` vb.
- **Implementasyonlar**:
  - `EfAnimalRepository`, `EfUserRepository` vb.

## Temel Özellikler

### Kullanıcı Yönetimi:
- Kayıt olma
- Giriş yapma
- Profil görüntüleme
- Yönetici ve normal kullanıcı ayrımı

### Hayvan Yönetimi:
- Yeni hayvan ekleme
- Hayvan bilgilerini düzenleme
- Hayvanları listeleme
- Türlere göre filtreleme

### Etkileşim:
- Hayvanlar hakkında yorum ekleme
- Hayvan detaylarını görüntüleme

### Güvenlik:
- Yetkilendirme kontrolleri
- Rol bazlı erişim yönetimi
- Güvenli şifre yönetimi

## Veritabanı İlişkileri:
- Bir kullanıcı birden fazla hayvan yönetebilir
- Bir hayvan birden fazla türe sahip olabilir
- Bir hayvan hakkında birden fazla yorum yapılabilir
- Her yorum bir kullanıcı ve bir hayvan ile ilişkilidir

## Özet
Bu web uygulaması, modern web teknolojilerini kullanarak kapsamlı bir hayvan barınağı yönetim sistemi sunmaktadır. **ASP.NET Core MVC** ve **Entity Framework Core** kullanılarak geliştirilmiştir ve Clean Architecture prensiplerini takip eden güvenli ve ölçeklenebilir bir yapıya sahiptir. Güvenlik özellikleri arasında cookie tabanlı kimlik doğrulama ve rol tabanlı yetkilendirme bulunur. Kod tekrarını önlemek için view componentler kullanılmıştır.
