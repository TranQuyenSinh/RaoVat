import { useState } from 'react'

export const useConfirmModal = () => {
    const [isOpen, setIsOpen] = useState(false)
    const toggle = () => {
        setIsOpen(!isOpen)
    }
    return [isOpen, toggle]
}
