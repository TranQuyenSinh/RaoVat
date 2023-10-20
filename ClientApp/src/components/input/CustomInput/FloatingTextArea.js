import React, { useId, useRef, useState } from 'react'
import './FloatingTextArea.scss'

const FloatingTextArea = ({ label, className, required, height = '150px', ...others }) => {
    const id = useId()

    return (
        <div className='form-floating mb-3'>
            <textarea
                style={{ height: height }}
                className={`form-control ${className}`}
                id={id}
                {...others}
                placeholder='123'></textarea>
            <label htmlFor={id}>
                {label} {required ? <span className='text-danger'>*</span> : ''}
            </label>
        </div>
    )
}

export default FloatingTextArea
