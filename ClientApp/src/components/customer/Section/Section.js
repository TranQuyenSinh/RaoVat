import React from 'react'
import './Section.scss'

const Section = ({ children, className: otherClass, ...otherProps }) => {
    return (
        <div className={`section-container ${otherClass}`} {...otherProps}>
            {children}
        </div>
    )
}

export default Section
