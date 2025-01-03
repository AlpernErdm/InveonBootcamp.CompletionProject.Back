# InveonBootcamp Completion Project API

## Bilgi
Bu API, Inveon FullStack Developer Bootcamp kapsamında geliştirilmiştir. Kullanıcı yönetimi, kurs yönetimi, sipariş ve ödeme işlemlerini içermektedir.

Bu dokümantasyon, InveonBootcamp Tamamlama Projesi kapsamında geliştirilen API'yi kullanmaya yönelik ayrıntılı bilgileri içerir. Her bir uç nokta için gerekli istek ve yanıt formatları sağlanmıştır. Bu dökümantasyon, işlemleri düzgün bir şekilde yerine getirmek için geliştiricilere rehberlik eder.

### API Detayları:
- **Versiyon**: 1.0
- **Temel URL**: `/api`

---

## Auth (Kimlik Doğrulama) Uç Noktaları

### 1. Kullanıcı Girişi
- **Uç Nokta**: `POST /api/Auth/LoginUser`
- **Açıklama**: Kullanıcı girişi yapar ve JWT token döner.
- **İstek Gövdesi**:
  ```json
  {
    "username": "string",
    "password": "string"
  }

Yanıt:
{
  "authenticateResult": true,
  "authToken": "string",
  "accessTokenExpireDate": "2023-01-01T00:00:00Z"
}



Kurs Uç Noktaları (Course Endpoints)

1. Tüm Kursları Getir


Uç Nokta: GET /api/Course/GetCourses

Açıklama: Tüm kursları listeler.

Yanıt:
[
  {
    "id": 1,
    "name": "Kurs Adı",
    "description": "Kurs Açıklaması",
    "price": 100,
    "category": "Kategori"
  }
]



2. Kurs Oluştur


Uç Nokta: POST /api/Course/Create

Açıklama: Yeni bir kurs oluşturur.

İstek Gövdesi:
{
  "name": "Kurs Adı",
  "description": "Kurs Açıklaması",
  "price": 100,
  "category": "Kategori"
}


Yanıt:
{
  "id": 1,
  "name": "Kurs Adı",
  "description": "Kurs Açıklaması",
  "price": 100,
  "category": "Kategori"
}



3. ID'ye Göre Kurs Getir


Uç Nokta: GET /api/Course/GetCourse/{id}

Açıklama: Belirli ID'ye sahip kursu getirir.

Yanıt:
{
  "id": 1,
  "name": "Kurs Adı",
  "description": "Kurs Açıklaması",
  "price": 100,
  "category": "Kategori"
}



4. Kurs Güncelle


Uç Nokta: PUT /api/Course/UpdateCourse/{id}

Açıklama: Belirli ID'ye sahip kursu günceller.

İstek Gövdesi:
{
  "name": "Güncellenmiş Kurs Adı",
  "description": "Güncellenmiş Kurs Açıklaması",
  "price": 150,
  "category": "Güncellenmiş Kategori"
}


Yanıt:
{
  "id": 1,
  "name": "Güncellenmiş Kurs Adı",
  "description": "Güncellenmiş Kurs Açıklaması",
  "price": 150,
  "category": "Güncellenmiş Kategori"
}



5. Kurs Sil


Uç Nokta: DELETE /api/Course/DeleteCourse/{id}

Açıklama: Belirli ID'ye sahip kursu siler.

Yanıt:
{
  "message": "Kurs başarıyla silindi."
}



Sipariş Uç Noktaları (Order Endpoints)

1. Tüm Siparişleri Getir


Uç Nokta: GET /api/Order/GetOrders

Açıklama: Tüm siparişleri listeler.

Yanıt:
[
  {
    "id": 1,
    "userId": "kullanıcı-id",
    "orderDate": "2023-01-01T00:00:00Z",
    "orderCourses": [...],
    "payment": {...}
  }
]



2. Sipariş Oluştur


Uç Nokta: POST /api/Order/CreateOrder

Açıklama: Yeni bir sipariş oluşturur.

İstek Gövdesi:
{
  "userId": "kullanıcı-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...]
}


Yanıt:
{
  "id": 1,
  "userId": "kullanıcı-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...],
  "payment": {...}
}



3. ID'ye Göre Sipariş Getir


Uç Nokta: GET /api/Order/GetOrder/{id}

Açıklama: Belirli ID'ye sahip siparişi getirir.

Yanıt:
{
  "id": 1,
  "userId": "kullanıcı-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...],
  "payment": {...}
}



4. Sipariş Güncelle


Uç Nokta: PUT /api/Order/UpdateOrder/{id}

Açıklama: Belirli ID'ye sahip siparişi günceller.

İstek Gövdesi:
{
  "userId": "güncellenmiş-kullanıcı-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...]
}


Yanıt:
{
  "id": 1,
  "userId": "güncellenmiş-kullanıcı-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...],
  "payment": {...}
}



5. Sipariş Sil


Uç Nokta: DELETE /api/Order/DeleteOrder/{id}

Açıklama: Belirli ID'ye sahip siparişi siler.

Yanıt:
{
  "message": "Sipariş başarıyla silindi."
}



Ödeme Uç Noktaları (Payment Endpoints)

1. Tüm Ödemeleri Getir


Uç Nokta: GET /api/Payment/GetPayments

Açıklama: Tüm ödemeleri listeler.

Yanıt:
[
  {
    "id": 1,
    "amount": 100,
    "paymentStatus": "Paid",
    "paymentDate": "2023-01-01T00:00:00Z",
    "orderId": 1
  }
]



2. Ödeme Oluştur


Uç Nokta: POST /api/Payment/PostPayment

Açıklama: Yeni bir ödeme oluşturur.

İstek Gövdesi:
{
  "amount": 100,
  "paymentStatus": "Paid",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}


Yanıt:
{
  "id": 1,
  "amount": 100,
  "paymentStatus": "Paid",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}



3. ID'ye Göre Ödeme Getir


Uç Nokta: GET /api/Payment/GetPayment/{id}

Açıklama: Belirli ID'ye sahip ödemeyi getirir.

Yanıt:
{
  "id": 1,
  "amount": 100,
  "paymentStatus": "Paid",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}



4. Ödeme Güncelle


Uç Nokta: PUT /api/Payment/PutPayment/{id}

Açıklama: Belirli ID'ye sahip ödemeyi günceller.

İstek Gövdesi:
{
  "amount": 150,
  "paymentStatus": "Updated Status",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}


Yanıt:
{
  "id": 1,
  "amount": 150,
  "paymentStatus": "Updated Status",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}



5. Ödeme Sil


Uç Nokta: DELETE /api/Payment/DeletePayment/{id}

Açıklama: Belirli ID'ye sahip ödemeyi siler.

Yanıt:
{
  "message": "Ödeme başarıyla silindi."
}



Kullanıcı Uç Noktaları (User Endpoints)

1. Tüm Kullanıcıları Getir


Uç Nokta: GET /api/User/GetUsers

Açıklama: Tüm kullanıcıları listeler.

Yanıt:
[
  {
    "id": "user-id",
    "username": "kullanıcıadı",
    "password": "şifre",
    "email": "email@example.com",
    "phoneNumber": "telefon-numarası"
  }
]



2. Kullanıcı Oluştur


Uç Nokta: POST /api/User/RegisterUser

Açıklama: Yeni bir kullanıcı oluşturur.

İstek Gövdesi:
{
  "username": "kullanıcıadı",
  "password": "şifre",
  "email": "email@example.com",
  "phoneNumber": "telefon-numarası"
}


Yanıt:
{
  "id": "user-id",
  "username": "kullanıcıadı",
  "password": "şifre",
  "email": "email@example.com",
  "phoneNumber": "telefon-numarası"
}



3. ID'ye Göre Kullanıcı Getir


Uç Nokta: GET /api/User/GetUser/{id}

Açıklama: Belirli ID'ye sahip kullanıcıyı getirir.

Yanıt:
{
  "id": "user-id",
  "username": "kullanıcıadı",
  "password": "şifre",
  "email": "email@example.com",
  "phoneNumber": "telefon-numarası"
}



4. Kullanıcı Güncelle


Uç Nokta: PUT /api/User/UpdateUser/{id}

Açıklama: Belirli ID'ye sahip kullanıcıyı günceller.

İstek Gövdesi:
{
  "username": "güncellenmiş-kullanıcıadı",
  "password": "güncellenmiş-şifre",
  "email": "güncellenmiş-email@example.com",
  "phoneNumber": "güncellenmiş-telefon-numarası"
}


Yanıt:
{
  "id": "user-id",
  "username": "güncellenmiş-kullanıcıadı",
  "password": "güncellenmiş-şifre",
  "email": "güncellenmiş-email@example.com",
  "phoneNumber": "güncellenmiş-telefon-numarası"
}



5. Kullanıcı Sil


Uç Nokta: DELETE /api/User/DeleteUser/{id}

Açıklama: Belirli ID'ye sahip kullanıcıyı siler.

Yanıt:
{
  "message": "Kullanıcı başarıyla silindi."
}



6. Kullanıcı Email İle Getir


Uç Nokta: GET /api/User/GetUserByEmail/{email}

Açıklama: Belirli email'e sahip kullanıcıyı getirir.

Yanıt:
{
  "id": "user-id",
  "username": "kullanıcıadı",
  "password": "şifre",
  "email": "email@example.com",
  "phoneNumber": "telefon-numarası"
}




Kullanım Şekli

Çeşitli uç noktalara istek göndermek için aşağıdaki adımları izleyin:



Postman veya benzeri bir araç kullanarak uygun HTTP metodunu seçin (GET, POST, PUT, DELETE).

Uç nokta URL'sini yapıştırın.

Gerekli durumlarda istek gövdesini (request body) JSON formatında sağlayın.

İsteği gönderin (Send) ve yanıtı görün.


