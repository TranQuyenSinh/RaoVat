import React, { useEffect, useState } from 'react'

import { Tab, Tabs, TabList, TabPanel } from 'react-tabs'
import 'react-tabs/style/react-tabs.css'
import Section from '../../../components/customer/Section/Section'

import no_avatar from '../../../assets/images/no_avatar.png'

import './ManageAd.scss'
import { useDispatch, useSelector } from 'react-redux'
import DisplayAds from './DisplayAds'
import HiddenAds from './HiddenAds'
import { getAdStatusCount } from '../../../services'
const ManageAd = () => {
    const [statusCount, setStatusCount] = useState({
        display: 0,
        expired: 0,
        rejected: 0,
        waiting: 0,
        hidden: 0,
    })

    const [hiddenAdCount, setHiddenAdCount] = useState(0)

    const { currentUser, isLoggedIn } = useSelector(state => state.user)
    const resetCount = async () => {
        let { data } = await getAdStatusCount()
        setStatusCount(data)
    }
    useEffect(() => {
        document.title = 'Rao vặt - Quản lý tin'
        resetCount()
    }, [])
    return (
        <Section className='manage-ad-container'>
            <div className='user'>
                <img src={currentUser?.avatar || no_avatar} className='user__avatar' alt='' />
                <span className='fw-bold ms-2 fs-5'>{currentUser?.fullName}</span>
            </div>
            <Tabs>
                <TabList>
                    <Tab>Tin đang hiển thị ({statusCount.display})</Tab>
                    <Tab>Hết hạn ({statusCount.expired})</Tab>
                    <Tab>Bị từ chối ({statusCount.rejected})</Tab>
                    <Tab>Chờ duyệt ({statusCount.waiting})</Tab>
                    <Tab>Đã ẩn ({statusCount.hidden})</Tab>
                </TabList>

                <TabPanel>
                    <DisplayAds resetCount={resetCount} />
                </TabPanel>
                <TabPanel>
                    <h2>Danh sách tin Hết hạn</h2>
                </TabPanel>
                <TabPanel>
                    <h2>Danh sách tin Bị từ chối</h2>
                </TabPanel>
                <TabPanel>
                    <h2>Danh sách tin Chờ duyệt</h2>
                </TabPanel>
                <TabPanel>
                    <HiddenAds resetCount={resetCount} />
                </TabPanel>
            </Tabs>
        </Section>
    )
}

export default ManageAd
