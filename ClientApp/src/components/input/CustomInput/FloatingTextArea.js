import React, { useId, useRef, useState } from 'react'
import './FloatingTextArea.scss'

const FloatingTextArea = ({ label, className, required, ...others }) => {
    const [height, setHeight] = useState('100px')

    const id = useId()

    return (
        <div className='form-floating mb-3'>
            <textarea
                onFocus={() => setHeight('150px')}
                onBlur={() => setHeight('100px')}
                className={`form-control ${className}`}
                id={id}
                {...others}
                placeholder='123'
                style={{ height: height }}></textarea>
            <label htmlFor={id}>
                {label} {required ? <span className='text-danger'>*</span> : ''}
            </label>
        </div>
    )
}

export default FloatingTextArea
