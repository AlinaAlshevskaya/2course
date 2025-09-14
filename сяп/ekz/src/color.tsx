import React, { useState,  type ChangeEvent } from "react";

const FavoriteColor: React.FC = () => {
  const [color, setColor] = useState<string>("");

  const handleChange = (event: ChangeEvent<HTMLSelectElement>) => {
    setColor(event.target.value);
    
  };

  return (
    <div style={{ padding: "1rem", fontFamily: "Arial, sans-serif" }}>
      <h2>Пожалуйста, выберите ваш любимый цвет:</h2>
      <select value={color} onChange={handleChange}>
        <option value="">-- Выберите цвет --</option>
        <option value="red">Красный</option>
        <option value="green">Зелёный</option>
        <option value="blue">Синий</option>
        <option value="yellow">Жёлтый</option>
        <option value="purple">Фиолетовый</option>
      </select>

       {document.body.style.background=color}
        
          
        
    
    </div>
   
  );
};

export default FavoriteColor;

