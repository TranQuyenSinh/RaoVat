import React, { useId } from 'react'
import './FloatingInput.scss'
const FloatingInput = ({ label, className, required, ...others }) => {
    const id = useId()
    return (
        <div className='form-floating mb-3'>
            <input className={`form-control ${className}`} id={id} {...others} placeholder='123' />
            <label htmlFor={id}>
                {label} {required ? <span className='text-danger'>*</span> : ''}
            </label>
        </div>
    )
}

export default FloatingInput
