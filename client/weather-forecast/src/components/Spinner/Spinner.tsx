import './index.css';

const Spinner = () => {
  return (
    <div className='loader'>
      <div className='sk-chase'>
        <div className='sk-chase-dot'></div>
        <div className='sk-chase-dot'></div>
        <div className='sk-chase-dot'></div>
        <div className='sk-chase-dot'></div>
        <div className='sk-chase-dot'></div>
        <div className='sk-chase-dot'></div>
      </div>
    </div>
  );
};

export { Spinner };
