import { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import api from '../services/api'

function Dashboard() {
  const [events, setEvents] = useState([])
  const navigate = useNavigate()

  useEffect(() => {
    const token = localStorage.getItem('token')
    api.get('/dj/event', {
      headers: { Authorization: `Bearer ${token}` }
    })
    .then(res => {
  console.log('respuesta completa:', res.data)
  setEvents(res.data.events || [])
})
    .catch((err) => {
  console.log(err)
})
  }, [])

  return (
    <div>
      <h1>Mis Eventos</h1>
      <button onClick={() => navigate('/add-event')}>Agregar Evento</button>
      {events.length === 0 
        ? <p>No tenés eventos cargados</p>
        : events.map(e => (
            <div key={e.id}>
              <h3>{e.type}</h3>
              <p>Fecha: {new Date(e.date).toLocaleDateString()}</p>
              <p>Lugar: {e.loc}</p>
              <p>Estado: {e.es}</p>
              <p>Duracion: {e.duration}</p>
            </div>
          ))
      }
    </div>
  )

  
}

export default Dashboard