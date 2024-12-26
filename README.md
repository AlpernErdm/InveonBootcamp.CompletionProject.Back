# InveonBootcamp Completion Project API

## Bilgi
Bu API, InveonBootcamp Completion Project kapsamında geliştirilmiştir. Kullanıcı yönetimi, kurs yönetimi, sipariş ve ödeme işlemlerini içermektedir.

### API Detayları:
- **Versiyon**: 1.0
- **Base URL**: `/api`

---

## Auth Endpoints

### 1. User Login
- **Endpoint**: `POST /api/Auth/LoginUser`
- **Description**: Kullanıcı girişi yapar ve JWT token döner.
- **Request Body**:
  ```json
  {
    "username": "string",
    "password": "string"
  }
  
Response:
{
  "authenticateResult": true,
  "authToken": "string",
  "accessTokenExpireDate": "2023-01-01T00:00:00Z"
}




Course Endpoints

1. Get All Courses


Endpoint: GET /api/Course

Description: Tüm kursları listeler.

Response:
[
  {
    "id": 1,
    "name": "Course Name",
    "description": "Course Description",
    "price": 100,
    "category": "Category"
  }
]



2. Create Course


Endpoint: POST /api/Course

Description: Yeni bir kurs oluşturur.

Request Body:
{
  "name": "Course Name",
  "description": "Course Description",
  "price": 100,
  "category": "Category"
}


Response:
{
  "id": 1,
  "name": "Course Name",
  "description": "Course Description",
  "price": 100,
  "category": "Category"
}



3. Get Course by ID


Endpoint: GET /api/Course/{id}

Description: Belirli ID'ye sahip kursu getirir.

Response:
{
  "id": 1,
  "name": "Course Name",
  "description": "Course Description",
  "price": 100,
  "category": "Category"
}



4. Update Course


Endpoint: PUT /api/Course/{id}

Description: Belirli ID'ye sahip kursu günceller.

Request Body:
{
  "name": "Updated Course Name",
  "description": "Updated Course Description",
  "price": 150,
  "category": "Updated Category"
}


Response:
{
  "id": 1,
  "name": "Updated Course Name",
  "description": "Updated Course Description",
  "price": 150,
  "category": "Updated Category"
}



5. Delete Course


Endpoint: DELETE /api/Course/{id}

Description: Belirli ID'ye sahip kursu siler.

Response:
{
  "message": "Course deleted successfully."
}




Order Endpoints

1. Get All Orders


Endpoint: GET /api/Order

Description: Tüm siparişleri listeler.

Response:
[
  {
    "id": 1,
    "userId": "user-id",
    "orderDate": "2023-01-01T00:00:00Z",
    "orderCourses": [...],
    "payment": {...}
  }
]



2. Create Order


Endpoint: POST /api/Order

Description: Yeni bir sipariş oluşturur.

Request Body:
{
  "userId": "user-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...]
}


Response:
{
  "id": 1,
  "userId": "user-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...],
  "payment": {...}
}



3. Get Order by ID


Endpoint: GET /api/Order/{id}

Description: Belirli ID'ye sahip siparişi getirir.

Response:
{
  "id": 1,
  "userId": "user-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...],
  "payment": {...}
}



4. Update Order


Endpoint: PUT /api/Order/{id}

Description: Belirli ID'ye sahip siparişi günceller.

Request Body:
{
  "userId": "updated-user-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...]
}


Response:
{
  "id": 1,
  "userId": "updated-user-id",
  "orderDate": "2023-01-01T00:00:00Z",
  "orderCourses": [...],
  "payment": {...}
}



5. Delete Order


Endpoint: DELETE /api/Order/{id}

Description: Belirli ID'ye sahip siparişi siler.

Response:
{
  "message": "Order deleted successfully."
}




Payment Endpoints

1. Get All Payments


Endpoint: GET /api/Payment

Description: Tüm ödemeleri listeler.

Response:
[
  {
    "id": 1,
    "amount": 100,
    "paymentStatus": "Paid",
    "paymentDate": "2023-01-01T00:00:00Z",
    "orderId": 1
  }
]



2. Create Payment


Endpoint: POST /api/Payment

Description: Yeni bir ödeme oluşturur.

Request Body:
{
  "amount": 100,
  "paymentStatus": "Paid",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}


Response:
{
  "id": 1,
  "amount": 100,
  "paymentStatus": "Paid",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}



3. Get Payment by ID


Endpoint: GET /api/Payment/{id}

Description: Belirli ID'ye sahip ödemeyi getirir.

Response:
{
  "id": 1,
  "amount": 100,
  "paymentStatus": "Paid",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}



4. Update Payment


Endpoint: PUT /api/Payment/{id}

Description: Belirli ID'ye sahip ödemeyi günceller.

Request Body:
{
  "amount": 150,
  "paymentStatus": "Updated Status",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}


Response:
{
  "id": 1,
  "amount": 150,
  "paymentStatus": "Updated Status",
  "paymentDate": "2023-01-01T00:00:00Z",
  "orderId": 1
}



5. Delete Payment


Endpoint: DELETE /api/Payment/{id}

Description: Belirli ID'ye sahip ödemeyi siler.

Response:
{
  "message": "Payment deleted successfully."
}




User Endpoints

1. Get All Users


Endpoint: GET /api/User

Description: Tüm kullanıcıları listeler.

Response:
[
  {
    "id": "user-id",
    "username": "username",
    "password": "password",
    "role": "role",
    "adress": "address",
    "phoneNumber": "phone-number"
  }
]



2. Create User


Endpoint: POST /api/User

Description: Yeni bir kullanıcı oluşturur.

Request Body:
{
  "username": "username",
  "password": "password",
  "role": "role",
  "adress": "address",
  "phoneNumber": "phone-number"
}


Response:
{
  "id": "user-id",
  "username": "username",
  "password": "password",
  "role": "role",
  "adress": "address",
  "phoneNumber": "phone-number"
}



3. Get User by ID


Endpoint: GET /api/User/{id}

Description: Belirli ID'ye sahip kullanıcıyı getirir.

Response:
{
  "id": "user-id",
  "username": "username",
  "password": "password",
  "role": "role",
  "adress": "address",
  "phoneNumber": "phone-number"
}



4. Update User


Endpoint: PUT /api/User/{id}

Description: Belirli ID'ye sahip kullanıcıyı günceller.

Request Body:
{
  "username": "updated-username",
  "password": "updated-password",
  "role": "updated-role",
  "adress": "updated-address",
  "phoneNumber": "updated-phone-number"
}


Response:
{
  "id": "user-id",
  "username": "updated-username",
  "password": "updated-password",
  "role": "updated-role",
  "adress": "updated-address",
  "phoneNumber": "updated-phone-number"
}



5. Delete User


Endpoint: DELETE /api/User/{id}

Description: Belirli ID'ye sahip kullanıcıyı siler.

Response:
{
  "message": "User deleted successfully."
}




Kullanım Şekli

Çeşitli uç noktalara istek göndermek için aşağıdaki adımları izleyin:



Postman veya benzeri bir araç kullanarak uygun HTTP metodunu seçin (GET, POST, PUT, DELETE).

Uç nokta URL'sini yapıştırın.

Gerekli durumlarda istek gövdesini (request body) JSON formatında sağlayın.

İstasyona tıklayın (Send) ve yanıtı görün.
