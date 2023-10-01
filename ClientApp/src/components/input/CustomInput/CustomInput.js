import React, { useId } from 'react'
import './CustomInput.scss'
const CustomInput = ({ label, className, ...others }) => {
    const id = useId()
    return (
        <div className='form-floating mb-3'>
            <input className={`form-control ${className}`} id={id} {...others} placeholder='123' />
            <label htmlFor={id}>{label}</label>
        </div>
    )
}

export default CustomInput
