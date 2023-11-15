import React, { Children } from 'react'
import './FloatingSelect.scss'
const FloatingSelect = ({ label, className, children, placeholder = 'Chọn', ...props }) => {
    return (
        <div className={`form-floating ${className}`}>
            <select className='form-select' {...props}>
                <option className='text-muted' value={-1}>
                    {placeholder}
                </option>
                {children}
            </select>
            <label htmlFor='floatingSelect'>{label}</label>
        </div>
    )
}

export default FloatingSelect
