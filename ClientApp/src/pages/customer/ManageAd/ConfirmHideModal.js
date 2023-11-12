import React from 'react'
import { Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap'

const ConfirmHideModal = ({ isOpen, toggle, handleSubmit }) => {
    const onSubmit = () => {
        toggle()
        handleSubmit()
    }
    return (
        <Modal isOpen={isOpen} toggle={toggle} className='order-modal'>
            <ModalHeader>
                <strong>Xác nhận ẩn tin</strong>
                <span>
                    <button onClick={toggle} className='btn btn-close'></button>
                </span>
            </ModalHeader>
            <ModalBody>
                Khi bạn đã bán được hàng, hoặc không muốn tin xuất hiện trên Rao vặt, hãy chọn "Ẩn tin".
            </ModalBody>
            <ModalFooter>
                <div onClick={toggle} className='btn btn-outline-secondary text-uppercase' style={{ flex: 1 }}>
                    Hủy
                </div>
                <div onClick={onSubmit} className='btn btn-main text-uppercase' style={{ flex: 1 }}>
                    Ẩn tin
                </div>
            </ModalFooter>
        </Modal>
    )
}

export default ConfirmHideModal
