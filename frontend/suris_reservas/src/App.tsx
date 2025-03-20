import { useState, useEffect } from "react";

interface Service {
  id: number;
  name: string;
}

interface Reservation {
  id: number;
  serviceId: number;
  serviceName: string;
  date: string;
  time: string;
  clientId: number;
}
function App() {
  const [services, setServices] = useState<Service[]>([]);
  const [reservations, setReservations] = useState<Reservation[]>([]);
  const [selectedService, setSelectedService] = useState<number | "">("");
  const [date, setDate] = useState<string>("");
  const [time, setTime] = useState<string>("");
  const [clientId, setClientId] = useState<number | "">(""); 
  const [error, setError] = useState<string>("");

  useEffect(() => {
    fetch("https://localhost:7075/api/Service")
      .then((res) => res.json())
      .then(setServices);

    fetch("https://localhost:7075/api/Reservation")
      .then((res) => res.json())
      .then(setReservations);
  }, []);

  const handleReserve = async () => {
    if (!selectedService || !date || !time || !clientId) {
      setError("Todos los campos son obligatorios");
      return;
    }

    const formattedTime = `${time}:00`; // Ajustar formato a "HH:mm:ss"

    const newReservation = {
      serviceId: selectedService,
      date,
      time: formattedTime,
      clientId: Number(clientId), // Convertir a número si es string
    };

    const response = await fetch("https://localhost:7075/api/Reservation", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newReservation),
    });

    if (response.ok) {
      const createdReservation = await response.json();
      setReservations([...reservations, createdReservation]);
      setSelectedService("");
      setDate("");
      setTime("");
      setClientId("");
      setError("");
    } else {
      setError("No se pudo realizar la reserva");
    }
  };

  return (
    <div className="p-4 max-w-lg mx-auto">
      <h2 className="text-xl font-bold mb-4">Reservar Servicio</h2>
      {error && <p className="text-red-500">{error}</p>}
      <select
        value={selectedService}
        onChange={(e) => setSelectedService(Number(e.target.value))}
        className="border p-2 w-full mb-2"
      >
        <option value="">Seleccione un servicio</option>
        {services.map((s) => (
          <option key={s.id} value={s.id}>{s.name}</option>
        ))}
      </select>
      <input
        type="date"
        value={date}
        onChange={(e) => setDate(e.target.value)}
        className="border p-2 w-full mb-2"
      />
      <input
        type="time"
        value={time}
        onChange={(e) => setTime(e.target.value)}
        className="border p-2 w-full mb-2"
      />
      <input
        type="number"
        placeholder="ID del cliente"
        value={clientId}
        onChange={(e) => setClientId(e.target.value ? Number(e.target.value) : "")}
        className="border p-2 w-full mb-2"
      />
      <button onClick={handleReserve} className="bg-blue-500 text-white px-4 py-2 w-full">
        Reservar
      </button>
      <h2 className="text-xl font-bold mt-4">Reservas Realizadas</h2>
      <ul>
        {reservations.map((r) => (
          <li key={r.id} className="border p-2 my-1">
            {r.serviceName} - {new Date(r.date).toLocaleDateString()} {r.time.slice(0, 5)} - {r.clientId}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App
