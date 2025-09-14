import React, { useState } from 'react';

type TableProps = {
  title: string;
  rows: number;
  columns: number;
};

const Table: React.FC<TableProps> = ({ title, rows, columns }) => {
  const [showTitle, setShowTitle] = useState(false);

  return (
    <div
      onMouseEnter={() => setShowTitle(true)}
      onMouseLeave={() => setShowTitle(false)}
      style={{ display: 'inline-block', padding: '10px' }}
    >
      {showTitle && <h2 style={{ textAlign: 'center' }}>{title}</h2>}
      <table border={1} style={{ borderCollapse: 'collapse' }}>
        <tbody>
          {Array.from({ length: rows }).map((_, rowIndex) => (
            <tr key={rowIndex}>
              {Array.from({ length: columns }).map((_, colIndex) => (
                <td key={colIndex} style={{ padding: '10px' }}>
                  {`R${rowIndex + 1}C${colIndex + 1}`}
                </td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Table;