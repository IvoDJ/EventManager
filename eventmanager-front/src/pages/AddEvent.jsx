import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import api from '../services/api'

function AddEvent() {
  const [type, setType] = useState(1)
  const [date, setDate] = useState('')
  const [loc, setLoc] = useState('')
  const [state, setState] = useState(1)
  const [duration, setDuration] = useState(6)
  const navigate = useNavigate()

  const handleSubmit = async () => {
    try {
      const token = localStorage.getItem('token')
      await api.post('/dj/event', 
        { type, date, loc, state, duration },
        { headers: { Authorization: `Bearer ${token}` } }
      )
      navigate('/dashboard')
    } catch (err) {
      console.log(err)
      alert('Error al agregar el evento')
    }
  }

  return (
    <div>
      <h1>Agregar Evento</h1>
      <select value={type} onChange={e => setType(Number(e.target.value))}>
        <option value={0}>Quinceaños</option>
        <option value={1}>Boda</option>
        <option value={2}>Cumpleaños</option>
        <option value={3}>Bar Mitzvah</option>
        <option value={4}>Bat Mitzvah</option>
      </select>
      <input type="datetime-local" value={date} onChange={e => setDate(e.target.value)} />
      <input type="text" placeholder="Lugar" value={loc} onChange={e => setLoc(e.target.value)} />
      <select value={state} onChange={e => setState(Number(e.target.value))}>
        <option value={0}>Confirmado</option>
        <option value={1}>Pendiente</option>
        <option value={2}>Cancelado</option>
      </select>
      <input type="number" min={6} max={8} value={duration} onChange={e => setDuration(Number(e.target.value))} />
      <button onClick={handleSubmit}>Guardar</button>
      <button onClick={() => navigate('/dashboard')}>Cancelar</button>
    </div>
  )
}

export default AddEvent