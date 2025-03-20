
# Sistema de Gestión de Reservas

Este proyecto es una aplicación web para gestionar reservas de servicios. La aplicación incluye un backend en .NET 8 y un frontend en React. Los usuarios pueden seleccionar servicios, elegir una fecha y un horario disponible, y asociar la reserva a un cliente.

---

## 🚀 **Cómo ejecutar el proyecto**

### ✅ **Backend (API)**
1. Asegúrate de tener instalado **.NET 8** en tu máquina.  
2. Navega a la carpeta del backend desde la terminal:  
   ```bash
   cd Backend
   ```
3. Restaura los paquetes NuGet:  
   ```bash
   dotnet restore
   ```
4. Ejecuta el backend:  
   ```bash
   dotnet run
   ```
5. El backend se ejecutará en el puerto **7075**.  
   Puedes probar los endpoints en `https://localhost:7075/swagger`.

---

### ✅ **Frontend (React)**
1. Asegúrate de tener **Node.js** instalado.  
2. Navega a la carpeta del frontend desde la terminal:  
   ```bash
   cd Frontend
   ```
3. Instala las dependencias:  
   ```bash
   npm install
   ```
4. Ejecuta el frontend:  
   ```bash
   npm run dev
   ```
5. El frontend se ejecutará en el puerto **5173**.  
   Abre el navegador y ve a:  
   ```
   http://localhost:5173
   ```

---

## ⚙️ **Configuración**
Si es necesario cambiar los puertos o rutas, puedes modificar las siguientes configuraciones:

### **Backend**
- El puerto se configura en el archivo `appsettings.json`:
```json
"Kestrel": {
  "Endpoints": {
    "Http": {
      "Url": "http://localhost:7075"
    }
  }
}
```

### **Frontend**
- La URL de la API en el frontend se configura en el archivo `src/config.js`:
```javascript
export const API_BASE_URL = 'http://localhost:7075';
```

---

## 🧪 **Endpoints disponibles (Backend)**
| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/api/services` | Retorna el listado de servicios |
| `GET` | `/api/reservations` | Retorna todas las reservas generadas |
| `POST` | `/api/reservations` | Crea una nueva reserva (validando las restricciones) |

---

## ✅ **Estado del Proyecto**
✅ Backend funcional  
✅ Frontend funcional  
✅ Validaciones implementadas  
✅ Base de datos en memoria  

