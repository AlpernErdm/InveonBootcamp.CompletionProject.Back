
# 🧊 OData Query Parameters & Filters

Bu proje, **ASP.NET Core** ile OData destekli RESTful API uygulamasıdır. Aşağıda, OData ile desteklenen sorgu parametreleri ve örnek filtreleme ifadeleri yer almaktadır.

---

## 🛠 Genel Query Parametreleri

| Parametre            | Açıklama                              | Örnek Kullanım                  |
|----------------------|----------------------------------------|---------------------------------|
| `$count=true`        | Toplam kayıt sayısını döndürür         | `?$count=true`                  |
| `$top=10`            | En fazla 10 kayıt getirir              | `?$top=10`                      |
| `$skip=20`           | İlk 20 kaydı atlar                     | `?$skip=20`                     |
| `$select=Name`       | Sadece belirtilen alanları getirir     | `?$select=Name,Price`           |
| `$orderby=Name`      | Belirli bir alana göre sıralar         | `?$orderby=Name desc`           |
| `$expand=Category`   | İlgili tabloyu dahil eder (JOIN)       | `?$expand=Category`             |

---

## 🔎 Filtreleme (Filter) Örnekleri

### 🔗 Karşılaştırma Operatörleri

```
$filter=Name eq 'Domates'
$filter=Price ne 50
$filter=Quantity gt 100
$filter=Quantity ge 100
$filter=Quantity lt 50
$filter=Quantity le 50
```

---

### 🧠 Metin İşlemleri (String Functions)

```
$filter=startswith(Name, 'Dom')
$filter=endswith(Name, 'tes')
$filter=contains(Name, 'oma')
$filter=tolower(Name) eq 'domates'
$filter=toupper(Name) eq 'DOMATES'
$filter=trim(Name) eq 'Domates'
$filter=concat(Name, ' Fresh') eq 'Domates Fresh'
$filter=contains(tolower(Name), 'dom')
```

---

### ➗ Matematiksel Operatörler

```
$filter=Price add Quantity eq 150
$filter=Price sub 10 eq 40
$filter=Price mul 2 eq 100
$filter=Price div 2 eq 25
$filter=Price mod 3 eq 0
```

---

### 🔄 Mantıksal Operatörler

```
$filter=(Price gt 50) and (Quantity lt 200)
$filter=(Price lt 50) or (Quantity gt 300)
$filter=not (Price eq 50)
```

---

### 📅 Tarih/Zaman İşlemleri

```
$filter=OrderDate eq 2024-01-01T00:00:00Z
$filter=OrderDate ge 2024-01-01T00:00:00Z
$filter=OrderDate le 2024-12-31T23:59:59Z
$filter=year(OrderDate) eq 2024
$filter=month(OrderDate) eq 12
$filter=day(OrderDate) eq 29
$filter=hour(OrderDate) eq 14
$filter=minute(OrderDate) eq 30
$filter=second(OrderDate) eq 15
```

---

### 🔢 Diğer

```
$filter=Name eq null
$filter=Name ne null
$filter=Name in ('Domates', 'Biber', 'Patlıcan')
$filter=length(Name) eq 7
$filter=indexof(Name, 'oma') eq 1
$filter=substring(Name, 1, 3) eq 'oma'
```


Kurs Uç Noktaları (Course Endpoints)

1. **Tüm Kursları Getir**


Uç Nokta: GET /api/Course/GetCourses

Açıklama: Tüm kursları listeler.

Yanıt:
```json
[
  {
    "id": 1,
    "name": "Kurs Adı",
    "description": "Kurs Açıklaması",
    "price": 100,
    "category": "Kategori"
  }
]
```


2.**Kurs Oluştur**


Uç Nokta: POST /api/Course/Create

Açıklama: Yeni bir kurs oluşturur.

**İstek Gövdesi**:
```json
{
  "name": "Kurs Adı",
  "description": "Kurs Açıklaması",
  "price": 100,
  "category": "Kategori"
}

```

Yanıt:
```json
{
  "id": 1,
  "name": "Kurs Adı",
  "description": "Kurs Açıklaması",
  "price": 100,
  "category": "Kategori"
}
```


3. **ID'ye Göre Kurs Getir**


Uç Nokta: GET /api/Course/GetCourse/{id}

Açıklama: Belirli ID'ye sahip kursu getirir.

Yanıt:
```json
{
  "id": 1,
  "name": "Kurs Adı",
  "description": "Kurs Açıklaması",
  "price": 100,
  "category": "Kategori"
}
```


4. **Kurs Güncelle**


Uç Nokta: PUT /api/Course/UpdateCourse/{id}

Açıklama: Belirli ID'ye sahip kursu günceller.

**İstek Gövdesi**:
```json
{
  "name": "Güncellenmiş Kurs Adı",
  "description": "Güncellenmiş Kurs Açıklaması",
  "price": 150,
  "category": "Güncellenmiş Kategori"
}
```

Yanıt:
```json
{
  "id": 1,
  "name": "Güncellenmiş Kurs Adı",
  "description": "Güncellenmiş Kurs Açıklaması",
  "price": 150,
  "category": "Güncellenmiş Kategori"
}

```

5. **Kurs Sil**


Uç Nokta: DELETE /api/Course/DeleteCourse/{id}

Açıklama: Belirli ID'ye sahip kursu siler.

Yanıt:
```json
{
  "message": "Kurs başarıyla silindi."
}

```

Sipariş Uç Noktaları (Order Endpoints)

1. **Tüm Siparişleri Getir**


Uç Nokta: GET /api/Order/GetOrders

Açıklama: Tüm siparişleri listeler.

Yanıt:
```json
[
  {
    "id": 1,
    "userId": "kullanıcı-id",
    "orderDate": "2023-01-01T00:00:00Z",
    "orderCourses": [...],
    "payment": {...}
  }
]

```

2. **Sipariş Oluştur**


Uç Nokta: POST /api/Order/CreateOrder

Açıklama: Yeni bir sipariş oluşturur.

İstek Gövdesi:
```json
{
  "userId": "kullanıcı-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...]
}
```

Yanıt:
```json
{
  "id": 1,
  "userId": "kullanıcı-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...],
  "payment": {...}
}

```

3. **ID'ye Göre Sipariş Getir**


Uç Nokta: GET /api/Order/GetOrder/{id}

Açıklama: Belirli ID'ye sahip siparişi getirir.

Yanıt:
```json
{
  "id": 1,
  "userId": "kullanıcı-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...],
  "payment": {...}
}
```


4. **Sipariş Güncelle**


Uç Nokta: PUT /api/Order/UpdateOrder/{id}

Açıklama: Belirli ID'ye sahip siparişi günceller.

İstek Gövdesi:
```json
{
  "userId": "güncellenmiş-kullanıcı-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...]
}

```
Yanıt:
```json
{
  "id": 1,
  "userId": "güncellenmiş-kullanıcı-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...],
  "payment": {...}
}

```

5. **Sipariş Sil**


Uç Nokta: DELETE /api/Order/DeleteOrder/{id}

Açıklama: Belirli ID'ye sahip siparişi siler.

Yanıt:
```json
{
  "message": "Sipariş başarıyla silindi."
}


```
Ödeme Uç Noktaları (Payment Endpoints)

1. **Tüm Ödemeleri Getir**


Uç Nokta: GET /api/Payment/GetPayments

Açıklama: Tüm ödemeleri listeler.

Yanıt:
```json
[
  {
    "id": 1,
    "amount": 100,
    "paymentStatus": "Paid",
    "paymentDate": "2023-01-01T00:00:00Z",
    "orderId": 1
  }
]

```

2. **Ödeme Oluştur**


Uç Nokta: POST /api/Payment/PostPayment

Açıklama: Yeni bir ödeme oluşturur.

İstek Gövdesi:
```json
{
  "amount": 100,
  "paymentStatus": "Paid",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}
```

Yanıt:
```json
{
  "id": 1,
  "amount": 100,
  "paymentStatus": "Paid",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}
```


3. **ID'ye Göre Ödeme Getir**


Uç Nokta: GET /api/Payment/GetPayment/{id}

Açıklama: Belirli ID'ye sahip ödemeyi getirir.

Yanıt:
```json
{
  "id": 1,
  "amount": 100,
  "paymentStatus": "Paid",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}
```


4. **Ödeme Güncelle**


Uç Nokta: PUT /api/Payment/PutPayment/{id}

Açıklama: Belirli ID'ye sahip ödemeyi günceller.

İstek Gövdesi:
```json
{
  "amount": 150,
  "paymentStatus": "Updated Status",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}

```
Yanıt:
{
```json
  "id": 1,
  "amount": 150,
  "paymentStatus": "Updated Status",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}
```


5. **Ödeme Sil**


Uç Nokta: DELETE /api/Payment/DeletePayment/{id}

Açıklama: Belirli ID'ye sahip ödemeyi siler.

Yanıt:
```json
{
  "message": "Ödeme başarıyla silindi."
}

```

**Kullanıcı Uç Noktaları (User Endpoints)**

1. **Tüm Kullanıcıları Getir**


Uç Nokta: GET /api/User/GetUsers

Açıklama: Tüm kullanıcıları listeler.

Yanıt:
```json
[
  {
    "id": "user-id",
    "username": "kullanıcıadı",
    "password": "şifre",
    "email": "email@example.com",
    "phoneNumber": "telefon-numarası"
  }
]

```

2. **Kullanıcı Oluştur**


Uç Nokta: POST /api/User/RegisterUser

Açıklama: Yeni bir kullanıcı oluşturur.

İstek Gövdesi:
```json
{
  "username": "kullanıcıadı",
  "password": "şifre",
  "email": "email@example.com",
  "phoneNumber": "telefon-numarası"
}
```

Yanıt:
```json
{
  "id": "user-id",
  "username": "kullanıcıadı",
  "password": "şifre",
  "email": "email@example.com",
  "phoneNumber": "telefon-numarası"
}

```

3. **ID'ye Göre Kullanıcı Getir**


Uç Nokta: GET /api/User/GetUser/{id}

Açıklama: Belirli ID'ye sahip kullanıcıyı getirir.

Yanıt:
```json
{
  "id": "user-id",
  "username": "kullanıcıadı",
  "password": "şifre",
  "email": "email@example.com",
  "phoneNumber": "telefon-numarası"
}
```


4. **Kullanıcı Güncelle**


Uç Nokta: PUT /api/User/UpdateUser/{id}

Açıklama: Belirli ID'ye sahip kullanıcıyı günceller.

İstek Gövdesi:
```json
{
  "username": "güncellenmiş-kullanıcıadı",
  "password": "güncellenmiş-şifre",
  "email": "güncellenmiş-email@example.com",
  "phoneNumber": "güncellenmiş-telefon-numarası"
}

```
Yanıt:
```json
{
  "id": "user-id",
  "username": "güncellenmiş-kullanıcıadı",
  "password": "güncellenmiş-şifre",
  "email": "güncellenmiş-email@example.com",
  "phoneNumber": "güncellenmiş-telefon-numarası"
}

```

5. **Kullanıcı Sil**


Uç Nokta: DELETE /api/User/DeleteUser/{id}

Açıklama: Belirli ID'ye sahip kullanıcıyı siler.

Yanıt:
```json
{
  "message": "Kullanıcı başarıyla silindi."
}

```

6. **Kullanıcı Email İle Getir**


Uç Nokta: GET /api/User/GetUserByEmail/{email}

Açıklama: Belirli email'e sahip kullanıcıyı getirir.

Yanıt:
```json
{
  "id": "user-id",
  "username": "kullanıcıadı",
  "password": "şifre",
  "email": "email@example.com",
  "phoneNumber": "telefon-numarası"
}
```



Kullanım Şekli

Çeşitli uç noktalara istek göndermek için aşağıdaki adımları izleyin:



Postman veya benzeri bir araç kullanarak uygun HTTP metodunu seçin (GET, POST, PUT, DELETE).

Uç nokta URL'sini yapıştırın.

Gerekli durumlarda istek gövdesini (request body) JSON formatında sağlayın.

İsteği gönderin (Send) ve yanıtı görün.


